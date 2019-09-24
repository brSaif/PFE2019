using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class AddPurchaseInvoice : Form
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public static int usrId;
        public static int importId;
        public AddPurchaseInvoice(int uid,int impId)
        {
            InitializeComponent();
            usrId = uid;
            importId = impId;
        }

        private void AddPurchaseInvoice_Load(object sender, EventArgs e)
        {
            FadeIn(this,10);

            //Suplier list
            var supList = _unitOfWork.Supplier.AllSuppliers()
                .Select(c => c.Company).ToList();

            //component List
            var compList = _unitOfWork.Component.AllComponents()
                .Select(c => c.Name).ToList();

            foreach (var t in supList)
            {
                dwnSup.Items.Add(t);
            }

            foreach (var t in compList)
            {
                dwnComp.Items.Add(t);
            }

            if (btnAdd.Text == "Update")
            {
                var c = _unitOfWork.ImportingInvoice.Find(importId);
                var r = _unitOfWork.RawMaterials.Find(c.RawMaterialId);
                int indexC = dwnComp.Items.IndexOf(r.Composant.Name);
                int indexS = dwnSup.Items.IndexOf(c.Suplier.Company);
                dwnSup.selectedIndex = indexS;
                dwnComp.selectedIndex = indexC;
                txtPrice.Text = c.Price.ToString();
                txtDiscount.Text = c.Discount.ToString();
                txtRefNumb.Text = r.RefNbr;
                txtLot.Text = r.Lot;
                txtMass.Text = r.Mass.ToString();

            }
        }
        

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _unitOfWork.Dispose();
            this.Hide();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you confirm to proceed the operation ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                if (btnAdd.Text == "Add New")
                {
                    try
                    {
                        var CompID = _unitOfWork.Component.SingleOrDefault(c => c.Name == dwnComp.selectedValue).Id;
                        var Mass = Convert.ToSingle(txtMass.Text);
                        var SupplierID = _unitOfWork.Supplier.SingleOrDefault(c => c.Company == dwnSup.selectedValue).Id;
                        var discount = Convert.ToSingle(txtDiscount.Text);
                        var price = Convert.ToSingle(txtPrice.Text);
                        var Lot = txtLot.Text;
                        var RefNumb = txtRefNumb.Text;
                        var PSt = Pstatus();
                        var PType = Ptype();

                        RawMaterial rm = new RawMaterial
                        {
                            ComposantID = CompID,
                            RefNbr = RefNumb,
                            Mass = Mass,
                            Lot = Lot,
                            ImpDate = DateTime.Today,
                            UpDate = DateTime.Today,
                            UserId = usrId,
                            Status = RawMaterial.RMStatus.Available
                        };

                        _unitOfWork.RawMaterials.InsertOrUpdate(rm);

                        ImportingInvoice im = new ImportingInvoice
                        {
                            SuplierId = SupplierID,
                            RawMaterial = rm,
                            Price = price,
                            Discount = discount,
                            PaymentStatus = PSt,
                            PaymentType = PType,
                            UserId = usrId,
                            CreatedDate = DateTime.Today
                        };

                        _unitOfWork.ImportingInvoice.InsertOrUpdate(im);
                        _unitOfWork.Complete();
                        MessageBox.Show("You Successfully Created Importing Invoice", "Success", MessageBoxButtons.OK);
                        _unitOfWork.Dispose();
                        this.Hide();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    } 
                }
                else
                {
                    var c = _unitOfWork.ImportingInvoice.Find(importId);
                    var r = _unitOfWork.RawMaterials.Find(c.RawMaterialId);
                    var suplier = _unitOfWork.Supplier.SingleOrDefault(t => t.Company == dwnSup.selectedValue).Id;

                    c.UserId = usrId;
                    c.Discount = Convert.ToSingle(txtDiscount.Text);
                    c.Price = Convert.ToSingle(txtPrice.Text);
                    c.SuplierId = suplier;
                    c.PaymentStatus = Pstatus();
                    c.PaymentType = Ptype();

                    _unitOfWork.ImportingInvoice.InsertOrUpdate(c);
                    var component = _unitOfWork.Component.SingleOrDefault(t => t.Name == dwnComp.selectedValue);

                    r.Composant = component;
                    r.Lot = txtLot.Text;
                    r.Mass = Convert.ToSingle(txtMass.Text);
                    r.RefNbr = txtRefNumb.Text;
                    r.UserId = usrId;
                    r.UpDate = DateTime.Today;

                    _unitOfWork.RawMaterials.InsertOrUpdate(r);
                    _unitOfWork.Complete();
                    MessageBox.Show("You Successfully Updated Importing Invoice", "Success", MessageBoxButtons.OK);
                    this.Hide();
                }
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

        private void S1(object sender, EventArgs e)
        {
            Unpaid.Checked = true;
            paid.Checked = false;
        }

        private void S2(object sender, EventArgs e)
        {
            Unpaid.Checked = false;
            paid.Checked = true;
        }

        private void bank(object sender, EventArgs e)
        {
            Bank.Checked = true;
            Cash.Checked = false;
            Term.Checked = false;
            Held.Checked = false;
        }

        private void cash(object sender, EventArgs e)
        {
            Bank.Checked = false;
            Cash.Checked = true;
            Term.Checked = false;
            Held.Checked = false;
        }

        private void term(object sender, EventArgs e)
        {
            Bank.Checked = false;
            Cash.Checked = false;
            Term.Checked = true;
            Held.Checked = false;
        }

        private void held(object sender, EventArgs e)
        {
            Bank.Checked = false;
            Cash.Checked = false;
            Term.Checked = false;
            Held.Checked = true;
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

        private void TxtMass_KeyPress(object sender, KeyPressEventArgs e)
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
