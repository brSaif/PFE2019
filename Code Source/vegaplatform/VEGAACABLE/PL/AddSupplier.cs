using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using VEGAACABLE.DAL.Repositories;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class AddSupplier : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());

        public AddSupplier()
        {
            InitializeComponent();
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            FadeIn(this, 10);

            ImpCatDwn.Items.Add("Copper");
            ImpCatDwn.Items.Add("Plastic");
            if (btnAdd.Text == "Update")
            {
                var supl = _UnitOfWork.Supplier.Find(Convert.ToInt16(lblId.Text));
                int index = ImpCatDwn.Items.IndexOf(supl.Category.ToString());
                ImpCatDwn.selectedIndex = index; 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text != "" 
                && txtCompany.Text != ""
                && txtEmail.Text != ""
                && txtFirstName.Text != ""
                && txtLastName.Text != ""
                && txtPhone.Text != ""
                && ImpCatDwn.selectedIndex != -1)
            {
                try
                {


                    if (btnAdd.Text == "Update")
                    {
                        var supl = _UnitOfWork.Supplier.Find(Convert.ToInt16(lblId.Text));
                        var category = ImpCatDwn.selectedValue;
                        supl.Company = txtCompany.Text;
                        supl.FirstName = txtFirstName.Text;
                        supl.LastName = txtLastName.Text;
                        supl.Phone = Convert.ToInt32(txtPhone.Text);
                        supl.Email = txtEmail.Text;
                        supl.Adress = txtAdress.Text;
                        supl.Category = ParseEnum<Suplier.Cat>(category);
                        _UnitOfWork.Supplier.InsertOrUpdate(supl);
                        _UnitOfWork.Complete();

                        this.Hide();

                    }

                    else
                    {
                        var category = ImpCatDwn.selectedValue;
                        var Suplier = new Suplier
                        {
                            Company = txtCompany.Text,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Phone = Convert.ToInt32(txtPhone.Text),
                            Email = txtEmail.Text,
                            Adress = txtAdress.Text,
                            Category = ParseEnum<Suplier.Cat>(category)
                        };

                        _UnitOfWork.Supplier.InsertOrUpdate(Suplier);
                        _UnitOfWork.Complete();

                        this.Hide();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } /**/
            }else
            {
                MessageBox.Show("Looks Like You Miseed Something. Check All Text Boxes Are Filled ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Covert Dropdown  selected value to enum
        public static T ParseEnum<T>(string value)              
        {
            return (T)Enum.Parse(typeof(T), value);
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

        private void AddSupplier_KeyPress(object sender, KeyPressEventArgs e)
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
