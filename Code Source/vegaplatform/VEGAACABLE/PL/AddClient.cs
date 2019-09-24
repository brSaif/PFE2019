
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            FadeIn(this,10);
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (btnAdd.Text == "Update")
            {
                using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var client = _UnitOfWork.Clients.Find(Convert.ToInt32(lblId.Text));
                    client.Adress = txtAdress.Text;
                    client.Company = txtCompany.Text;
                    client.Email = txtEmail.Text;
                    client.FirstName = txtFirstName.Text;
                    client.LastName = txtLastName.Text;
                    client.Phone = Convert.ToInt32(txtPhone.Text);
                    _UnitOfWork.Clients.InsertOrUpdate(client);
                    _UnitOfWork.Complete();

                }

                this.Hide();

            }
        
            else
            {
                using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var client = new Client
                    {
                        Company = txtCompany.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = Convert.ToInt32(txtPhone.Text),
                        Email = txtEmail.Text,
                        Adress = txtAdress.Text
                    };
                    _UnitOfWork.Clients.InsertOrUpdate(client);
                    _UnitOfWork.Complete();

                }
                this.Hide();


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

        private void LblP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
