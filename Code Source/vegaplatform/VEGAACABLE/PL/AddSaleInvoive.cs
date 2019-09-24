using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class AddSaleInvoive : Form
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public static int usrId;
        public static string st;
        private static int m = 0;
        public static int SellingID;

        public AddSaleInvoive(int uid,int sid)
        {
            InitializeComponent();
            usrId = uid;
            SellingID = sid;
        }

        private void AddSaleInvoive_Load(object sender, EventArgs e)
        {
            FadeIn(this, 10);

            Cash.Checked = false;
            Held.Checked = true;
            Bank.Checked = false;
            Term.Checked = false;
            Paid.Checked = false;
            Unpaid.Checked = true;

            //Client list
            var clist = _unitOfWork.Clients.AllClients()
                .Select(c => c.Company).ToList();

            //Nomenclatures List
            var nlist = _unitOfWork.Nomenclature.AllNomenclatures()
                .Select(c => c.Designation).ToList();

            foreach (var t in clist)
            {
                dwnClient.Items.Add(t);
            }

            foreach (var v in nlist)
            {
                dwnNomcl.Items.Add(v);
            }

            if(btnAdd.Text == "Update")
            {
                var s = _unitOfWork.SellingInvoices.Find(SellingID);
                var c = _unitOfWork.FabricationOrder.Find(s.FabOrdId);
                int indexC = dwnClient.Items.IndexOf(s.Client.Company);
                int indexN = dwnNomcl.Items.IndexOf(c.Nomenclature.Designation);
                dwnNomcl.selectedIndex = indexN;
                dwnClient.selectedIndex = indexC;
                txtLength.Text = c.Length.ToString();
                txtLength.Enabled = false;
                dwnNomcl.Enabled = false;
                btnValid.Enabled = false;
                dgvMaterials.Enabled = false;
            }

        }
        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add New")
            {
                DialogResult msg = MessageBox.Show("Do you confirm to proceed the operation ?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvMaterials.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[2].Value.ToString()) > Convert.ToInt32(row.Cells[3].Value.ToString()))
                        {
                            m = m + 1;
                            st = row.Cells[0].Value.ToString() + ", " + st;
                        }
                    }


                    if (m == 0)
                    {
                        try
                        {
                            var NomclaID = _unitOfWork.Nomenclature.SingleOrDefault(c => c.Designation == dwnNomcl.selectedValue).Id;
                            var length = Convert.ToSingle(txtLength.Text);
                            var Client = _unitOfWork.Clients.SingleOrDefault(c => c.Company == dwnClient.selectedValue).Id;
                            var discount = Convert.ToSingle(txtDiscount.Text);
                            var price = Convert.ToSingle(txtPrice.Text);
                            var PSt = Pstatus();
                            var PType = Ptype();

                            BL.Domain.FabricationOrder fo = new BL.Domain.FabricationOrder
                            {
                                NomenclatureId = NomclaID,
                                Length = length,
                                Status = BL.Domain.FabricationOrder.stat.Pending,
                                CreationDate = DateTime.Today,
                                StartingDate = DateTime.Today
                            };

                            _unitOfWork.FabricationOrder.InsertOrUpdate(fo);

                            SellingInvoice si = new SellingInvoice
                            {
                                FabricationOrder = fo,
                                ClientId = Client,
                                Price = price,
                                Discount = discount,
                                PaymentStatus = PSt,
                                PaymentType = PType,
                                UserId = usrId,
                                CreatedDate = DateTime.Today
                            };

                            _unitOfWork.SellingInvoices.InsertOrUpdate(si);

                            foreach (DataGridViewRow r in dgvMaterials.Rows)
                            {
                                var compName = r.Cells[0].Value.ToString();
                                var TotalMass = Convert.ToSingle(r.Cells[2].Value.ToString());
                                var AvailRawMList = _unitOfWork.RawMaterials.AllRawMaterials()
                                    .Where(c => c.Status == RawMaterial.RMStatus.Available
                                                || c.Status == RawMaterial.RMStatus.Reserved
                                                && c.Composant.Name == compName)
                                    .OrderBy(c => c.Mass).ToList();
                                int i = 0;
                                if (AvailRawMList.Count > 0)
                                {
                                    if (AvailRawMList[i].Mass > TotalMass)
                                    {
                                        var rest = AvailRawMList[i].Mass - TotalMass;
                                        UsedRawMaterial urm = new UsedRawMaterial
                                        {
                                            FabricationOrder = fo,
                                            RawMaterial = AvailRawMList[i],
                                            Weight = rest
                                        };

                                        _unitOfWork.UsedRawMaterial.InsertOrUpdate(urm);

                                        var rawMaterial = _unitOfWork.RawMaterials.Find(AvailRawMList[i].ID);
                                        rawMaterial.Status = RawMaterial.RMStatus.Reserved;

                                        _unitOfWork.RawMaterials.InsertOrUpdate(rawMaterial);

                                        i++;
                                    }
                                    else
                                    {
                                        UsedRawMaterial urm = new UsedRawMaterial
                                        {
                                            FabricationOrder = fo,
                                            RawMaterial = AvailRawMList[i],
                                            Weight = 0
                                        };

                                        _unitOfWork.UsedRawMaterial.InsertOrUpdate(urm);

                                        var rawMaterial = _unitOfWork.RawMaterials.Find(AvailRawMList[i].ID);
                                        rawMaterial.Status = RawMaterial.RMStatus.Reserved;

                                        _unitOfWork.RawMaterials.InsertOrUpdate(rawMaterial);
                                    }
                                    _unitOfWork.Complete();
                                }
                                else
                                {
                                    MessageBox.Show("There isn't enought Raw Material Available", "Warning"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }



                            MessageBox.Show("You Have Successfully Created Selling Invoice", "Succes"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {

                        MessageBox.Show("These Components " + st + " Are Unsufficient " +
                                        "To launch The Fab Order ", "Warning"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        st = "";
                    }
                } 
            }
            else
            {
                var s = _unitOfWork.SellingInvoices.Find(SellingID);
                var client = _unitOfWork.Clients.SingleOrDefault(c => c.Company == dwnClient.selectedValue);
                s.Client = client;
                s.Price = Convert.ToSingle(txtPrice.Text);
                s.Discount = Convert.ToSingle(txtDiscount.Text);
                s.PaymentStatus = Pstatus();
                s.PaymentType = Ptype();
                _unitOfWork.SellingInvoices.InsertOrUpdate(s);
                _unitOfWork.Complete();
                MessageBox.Show("You Successfully Updated Selling Invoice", "Success", MessageBoxButtons.OK);
                this.Hide();
            }

            this.Hide();

        }

        private void BtnValid_Click(object sender, EventArgs e)
        {
            dgvMaterials.Rows.Clear();
            try
            {

                if (dwnNomcl.selectedIndex != -1 && txtLength.Text != "")
                {
                    var nomclaId = _unitOfWork.Nomenclature
                        .SingleOrDefault(c => c.Designation == dwnNomcl.selectedValue.ToString()).Id;

                    var componentList = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(nomclaId)
                        .GroupBy(c => c.Component.Name)
                        .Select(c => new { Component = c.Key, TotalMass = c.Sum(t => t.Mass) });

                    var RawMList = _unitOfWork.RawMaterials.AllRawMaterials()
                        .GroupBy(c => c.Composant.Name)
                        .Select(c => new { Component = c.Key, TotalMassAvail = c.Sum(t => t.Mass) });
                    //Alternative way using repository pattern with linq regular syntax

                    //var listcomp = (from c in _context.NomenclatureSequenceses
                    //                where c.NomenclatureID == firstNID
                    //                join n in _context.Composants on c.ComposantId equals n.ID
                    //                group c by n.Designation into g
                    //                select new
                    //                {
                    //                    Composant = g.Key,
                    //                    MassTotale = g.Sum(c => c.Mass),
                    //                }).ToList();



                    //popuate dgvComp with data
                    foreach (var t in componentList)
                    {
                        foreach (var c in RawMList)
                        {
                            var requiredCompMass = t.TotalMass * Convert.ToSingle(txtLength.Text);
                            var RMMassAvail = c.TotalMassAvail;
                            if (t.Component == c.Component)
                            {
                                dgvMaterials.Rows.Add(t.Component, t.TotalMass, requiredCompMass, RMMassAvail);
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Make sure you selected a Nomenclature and set a Length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public PaymentMethod Ptype()
        {
            if (Held.Checked == true)
            {
                return PaymentMethod.Held;
            }
            else if (Cash.Checked == true)
            {
                return PaymentMethod.Cash;
            }
            else if (Bank.Checked == true)
            {
                return PaymentMethod.Bank;
            }
            else
            {
                return PaymentMethod.Term;
            }
        }

        public PaymentStatus Pstatus()
        {
            if (Unpaid.Checked == true)
            {
                return PaymentStatus.Unpaid;
            }
            else
            {
                return PaymentStatus.Paid;

            }
        }


        private void Paid_Click(object sender, EventArgs e)
        {
            Paid.Checked = true;
            Unpaid.Checked = false;
        }

        private void Term_Click(object sender, EventArgs e)
        {
            Term.Checked = true;
            Cash.Checked = false;
            Held.Checked = false;
            Bank.Checked = false;
        }

        private void Unpaid_Click(object sender, EventArgs e)
        {
            Paid.Checked = false;
            Unpaid.Checked = true;
        }

        private void Cash_Click(object sender, EventArgs e)
        {
            Cash.Checked = true;
            Term.Checked = false;
            Held.Checked = false;
            Bank.Checked = false;
        }

        private void Held_Click(object sender, EventArgs e)
        {
            Held.Checked = true;
            Cash.Checked = false;
            Term.Checked = false;
            Bank.Checked = false;
        }

        private void Bank_Click(object sender, EventArgs e)
        {
            Bank.Checked = true;
            Cash.Checked = false;
            Held.Checked = false;
            Term.Checked = false;
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
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
