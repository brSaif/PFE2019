using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;

namespace VEGAACABLE.PL
{
    public partial class Nomenclature : UserControl
    {
        //private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext()); 
        public Nomenclature()
        {
            InitializeComponent();
        }

        private void Nomenclature_Load(object sender, EventArgs e)
        {
                RefreshComp();
                RefreshSeq();
                RefreshNomcla();
                LoadSeqComp();
        }

        private void BtnAddSeq_Click(object sender, EventArgs e)
        {
            AddSequence m = new AddSequence(0);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
                RefreshSeq();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpSeq_Click(object sender, EventArgs e)
        {
            if (dgvSequence.Rows.Count > 0)
            {
                var seqId = Convert.ToInt32(dgvSequence.CurrentRow.Cells[0].Value);
                AddSequence m = new AddSequence(seqId);
                m.txtDesign.Text = dgvSequence.CurrentRow.Cells[1].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();
                RefreshSeq();
            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void BtnDelSeq_Click(object sender, EventArgs e)
        {
            if (dgvSequence.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var d = _unitOfWork.Sequence.Find(Convert.ToInt32(dgvSequence.CurrentRow.Cells[0].Value.ToString()));
                    _unitOfWork.Sequence.Remove(d);
                    _unitOfWork.Complete(); 
                }
                RefreshSeq(); 
            }
        }

        private void BtnAddComp_Click(object sender, EventArgs e)
        {
            AddComponent m = new AddComponent(0);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
                RefreshComp();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpComp_Click(object sender, EventArgs e)
        {
            if (dgvComponent.Rows.Count > 0)
            {
                var cmpID = Convert.ToInt32(dgvComponent.CurrentRow.Cells[0].Value);
                AddComponent m = new AddComponent(cmpID);
                m.txtDesign.Text = dgvComponent.CurrentRow.Cells[1].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();
                RefreshComp();
            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            
        }

        private void BtnDelComp_Click(object sender, EventArgs e)
        {
            if (dgvSeqComp.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var d = _unitOfWork.Component.Find(Convert.ToInt32(dgvComponent.CurrentRow.Cells[0].Value.ToString()));
                    _unitOfWork.Component.Delete(d.Id);
                    _unitOfWork.Complete();
                    RefreshComp(); 
                } 
            }
        }

        private void BtnAddNomcla_Click(object sender, EventArgs e)
        {
            AddNomenclature m = new AddNomenclature(0);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
                RefreshNomcla();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpNomcla_Click(object sender, EventArgs e)
        {
            if (dgvNomenclature.Rows.Count > 0)
            {
                var id = Convert.ToInt32(dgvNomenclature.CurrentRow.Cells[0].Value.ToString());
                AddNomenclature m = new AddNomenclature(id);
                m.txtDsg.Text = dgvNomenclature.CurrentRow.Cells[1].Value.ToString();
                m.txtNrR.Text = dgvNomenclature.CurrentRow.Cells[2].Value.ToString();
                m.txtCond.Text = dgvNomenclature.CurrentRow.Cells[3].Value.ToString();
                //m.cmbColr.selectedIndex = m.cmbColr.Items.IndexOf("RED");
                m.btnAdd.Text = "Update";
                m.ShowDialog();

                RefreshNomcla();
            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void BtnDelNomcla_Click(object sender, EventArgs e)
        {
            if (dgvNomenclature.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var d = _unitOfWork.Nomenclature.Find(Convert.ToInt32(dgvNomenclature.CurrentRow.Cells[0].Value.ToString()));
                    var b = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(d.Id);
                    _unitOfWork.NomenclatureSequence.RemoveRange(b);
                    _unitOfWork.Nomenclature.Remove(d);
                    _unitOfWork.Complete();
                    RefreshNomcla();  
                }
            }

        }

        private void DgvNomenclature_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSeqComp();
        }

        //some methods to refrech Data 

        public void RefreshComp()
        {
            using (var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var comp = _unitOfWork.Component.AllComponents()
                        .Select(c => new { ID = c.Id, Designation = c.Name }).ToList();
                if (comp.Any())
                {
                    dgvComponent.DataSource = comp;
                    dgvComponent.Columns[0].Width = 25;
                } 
            }
        }
        public void RefreshSeq()
        {
            using (var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var seqList = _unitOfWork.Sequence.AllSequences()
                        .Select(c => new { ID = c.Id, Designation = c.Name }).ToList();
                if (seqList.Any())
                {
                    dgvSequence.DataSource = seqList;
                    dgvSequence.Columns[0].Width = 25;
                } 
            }
        }
        public void RefreshNomcla()
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var nomcList = _unitOfWork.Nomenclature.AllNomenclatures()
                                .Select(c => new
                                {
                                    ID = c.Id,
                                    c.Designation,
                                    c.NormRef,
                                    c.Condition,
                                    Color = c.Color.Name
                                }).ToList();

                    if (nomcList.Any())
                    {
                        dgvNomenclature.DataSource = nomcList;
                        dgvNomenclature.Columns[0].Width = 25;
                    } 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadSeqComp()
        {
            if (dgvNomenclature.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var nmc = Convert.ToInt32(dgvNomenclature.CurrentRow.Cells[0].Value);
                    var ex = _unitOfWork.Nomenclature.Find(nmc);
                    var list = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(ex.Id)
                        .Select(c => new
                        {
                            ID = c.ID,
                            SeqID = c.Sequence.Id,
                            Sequence = c.Sequence.Name,
                            CompID = c.ComponentId,
                            Component = c.Component.Name
                        })
                        .ToList();

                    if (list.Any())
                    {
                        dgvSeqComp.DataSource = list;
                        dgvSeqComp.Columns[0].Width = 25;
                        dgvSeqComp.Columns[1].Width = 55;
                        dgvSeqComp.Columns[3].Width = 65;
                    }
                }
            }
        }

        private void Srch_TextChange(object sender, EventArgs e)
        {
            using(var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var nomcList = _unitOfWork.Nomenclature.AllNomenclatures()
                       .Where(c => c.Id.ToString().Contains(srch.Text)
                                   || c.Designation.ToString().Contains(srch.Text)
                                   || c.NormRef.ToString().Contains(srch.Text)
                                   || c.Condition.ToString().Contains(srch.Text)
                                   || c.Color.Name.ToString().ToLower().Contains(srch.Text.ToLower())
                       )
                       .Select(c => new
                       {
                           ID = c.Id,
                           c.Designation,
                           c.NormRef,
                           c.Condition,
                           Color = c.Color.Name
                       }).ToList();
                dgvNomenclature.DataSource = nomcList;
                dgvNomenclature.Columns[0].Width = 25;
            }

            if (dgvNomenclature.RowCount > 0)
            {
                LoadSeqComp();
            }
        }
    }
}
