using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;

namespace VEGAACABLE.PL
{
    public partial class AddNomenclature : Form
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public static int nmc;
        public AddNomenclature(int id)
        {
            InitializeComponent();
            nmc = id;
        }

        private void AddNomenclature_Load(object sender, EventArgs e)
        {
            //initialize combobox
            var colorList = _unitOfWork.Color.AllColors().Select(c => c.Name).ToList();
            var compList = _unitOfWork.Component.AllComponents().Select(c => c.Name).ToList();
            var seqList = _unitOfWork.Sequence.AllSequences().Select(c => c.Name).ToList();
            foreach (var d in colorList)
            {
                cmbColr.Items.Add(d);
            }
            foreach (var c in compList)
            {
                cmbComp.Items.Add(c);
            }
            foreach (var s in seqList)
            {
                cmbSeq.Items.Add(s);
            }

            //in case of update load seq/comp for the selected nomenclature
            if (btnAdd.Text == "Update")
            {
                var ex = _unitOfWork.Nomenclature.Find(nmc);
                var list = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(ex.Id);
                int index = cmbColr.Items.IndexOf(ex.Color.Name);
                cmbColr.selectedIndex = index;
                if (list.Any())
                {
                    foreach (var l in list)
                    {
                        //Add row in dgvMaterial
                        dgvMateriel.Rows.Add(l.SequenceId,
                            l.Sequence.Name,
                            l.ComponentId,
                            l.Component.Name,
                            l.Mass);
                    }
                }
            }
        }

        private void DgvMateriel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMateriel.Rows.Remove(dgvMateriel.CurrentRow);
        }

        private void BtnAtMat_Click(object sender, EventArgs e)
        {
            //verify and add rows to dgvMaterial
            if (cmbComp.Items.Count == 0
                || cmbSeq.Items.Count == 0)
            {
                MessageBox.Show("Hint : You have to create components and sequences first",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbSeq.selectedIndex == -1 || cmbComp.selectedIndex == -1 || txtConsoKm.Text == "")
            {
                MessageBox.Show("Hint : Make sure you heve selected from both sequences and component",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int m = 0;
                    foreach (DataGridViewRow i in dgvMateriel.Rows)
                    {

                        if (i.Cells[1].Value.ToString() == cmbSeq.selectedValue &&
                            i.Cells[3].Value.ToString() == cmbComp.selectedValue)
                        {
                            m++;
                        }
                    }

                    if (m == 0)
                    {
                        if (cmbComp.selectedIndex != 0)
                        {
                            //Add row in dgvMaterial
                            var s = _unitOfWork.Sequence.SingleOrDefault(q => q.Name == cmbSeq.selectedValue).Id;
                            var c = _unitOfWork.Component.SingleOrDefault(q => q.Name == cmbComp.selectedValue).Id;
                            dgvMateriel.Rows.Add(s, cmbSeq.selectedValue, c
                                , cmbComp.selectedValue
                                , txtConsoKm.Text);
                            //clear textbox text
                            txtConsoKm.Text = "";
                        }
                        else
                        {
                            //In case he chose to add sequence without components

                            var s = _unitOfWork.Sequence.SingleOrDefault(q => q.Name == cmbSeq.selectedValue).Id;
                            var c = _unitOfWork.Component.SingleOrDefault(q => q.Name == cmbComp.selectedValue).Id;
                            dgvMateriel.Rows.Add(s, cmbSeq.selectedValue, c
                                , cmbComp.selectedValue
                                , "0");
                            //clear textbox text
                            txtConsoKm.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("There exist a Sequence with the same component", "error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCond.Text != null && txtDsg.Text != null && txtNrR.Text != null && cmbColr.selectedIndex != -1)
                {
                    if (btnAdd.Text == "Add New")
                    {
                        var v = _unitOfWork.Nomenclature
                                            .AllNomenclatures().Count(c => c.Color.Name == cmbColr.selectedValue.ToString()
                                                                           && c.NormRef == txtNrR.Text
                                                                           && c.Condition == txtCond.Text);
                        if (v == 0)
                        {
                            var clr = cmbColr.selectedValue.ToString();
                            var color = _unitOfWork.Color.SingleOrDefault(c => c.Name == clr);
                            BL.Domain.Nomenclature n = new BL.Domain.Nomenclature
                            {
                                Designation = txtDsg.Text,
                                NormRef = txtNrR.Text,
                                Condition = txtCond.Text,
                                Color = color
                            };

                            _unitOfWork.Nomenclature.InsertOrUpdate(n);

                            foreach (DataGridViewRow i in dgvMateriel.Rows)
                            {
                                NomenclatureSequance nm = new NomenclatureSequance
                                {
                                    Nomenclature = n,
                                    SequenceId = Convert.ToInt32(i.Cells[0].Value.ToString()),
                                    ComponentId = Convert.ToInt32(i.Cells[2].Value.ToString()),
                                    Mass = Convert.ToSingle(i.Cells[4].Value.ToString()),
                                };
                                _unitOfWork.NomenclatureSequence.InsertOrUpdate(nm);
                            }
                            _unitOfWork.Complete();
                            MessageBox.Show("Nomenclature successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("This Nomenclature Already Existant "
                                , "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        var ex = _unitOfWork.Nomenclature.Find(nmc);
                        if (ex != null)
                        {
                            //first remove the list of nomclature sequences of that nomclature
                            var list = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(ex.Id);
                            _unitOfWork.NomenclatureSequence.RemoveRange(list);

                            //
                            var clr = cmbColr.selectedValue.ToString();
                            var color = _unitOfWork.Color.SingleOrDefault(c => c.Name == clr);
                            ex.Designation = txtDsg.Text;
                            ex.Condition = txtCond.Text;
                            ex.NormRef = txtNrR.Text;
                            ex.Color = color;

                            _unitOfWork.Nomenclature.InsertOrUpdate(ex);

                            //
                            foreach (DataGridViewRow t in dgvMateriel.Rows)
                            {
                                NomenclatureSequance nm = new NomenclatureSequance
                                {
                                    Nomenclature = ex,
                                    SequenceId = Convert.ToInt32(t.Cells[0].Value.ToString()),
                                    ComponentId = Convert.ToInt32(t.Cells[2].Value.ToString()),
                                    Mass = Convert.ToSingle(t.Cells[4].Value.ToString()),
                                };
                                _unitOfWork.NomenclatureSequence.InsertOrUpdate(nm);
                            }
                            _unitOfWork.Complete();
                            MessageBox.Show("You've Successfully Updated the Specified Component", "Success");
                            this.Hide();
                        }
                        
                    }

                }
                else
                {
                    MessageBox.Show("Make sure you filled all required fiels", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TxtConsoKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                                           && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
