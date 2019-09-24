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
    public partial class AddExpence : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int UserId;
        public static int expId;
        public AddExpence(int exId,int usrId)
        {
            InitializeComponent();
            expId = exId;
            UserId = usrId;
        }

        private void AddExpence_Load(object sender, EventArgs e)
        {
            
            var cat = _UnitOfWork.ExpenceCat.AllExpenceCats().Select(c => c.Name).ToList();

            if (cat.Any())
            {
                foreach (var t in cat)
                {
                    dwnCategories.Items.Add(t);
                }
            }

            if (btnAdd.Text == "Update")
            {
                var expence = _UnitOfWork.Expence.Find(expId);
                int index = dwnCategories.Items.IndexOf(expence.ExpenceCat.Name);
                dwnCategories.selectedIndex = index;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add New")
            {
                //Get category list
                var cat = _UnitOfWork.ExpenceCat.FirstOrDefault(c => c.Name == dwnCategories.selectedValue.ToString());

                //Add category 
                if (cat != null)
                {
                    Expence expence = new Expence
                    {
                        Payment = Convert.ToInt64(txtPaymnt.Text),
                        CreatedDate = DateTime.Now,
                        Description = txtDescrip.Text,
                        ExpenceCatId = cat.Id,
                        UserId = UserId
                    };
                    _UnitOfWork.Expence.InsertOrUpdate(expence);
                    _UnitOfWork.Complete();

                    MessageBox.Show("You've Successfully Added new Expence Category", "Success");
                    this.Hide();
                }

            }
            else
            {
                var expence = _UnitOfWork.Expence.Find(expId);
                if (dwnCategories.selectedIndex  != -1)
                {
                    if (expence != null)
                    {
                        // var cat = _UnitOfWork.ExpenceCat.FirstOrDefault(c => c.Name == dwnCategories.selectedValue.ToString());
                        expence.UserId = UserId;
                        expence.CreatedDate = DateTime.Now;
                        expence.Description = txtDescrip.Text;
                        expence.Payment = Convert.ToInt64(txtPaymnt.Text);
                        expence.ExpenceCat.Name = dwnCategories.selectedValue.ToString();
                        _UnitOfWork.Expence.InsertOrUpdate(expence);
                        _UnitOfWork.Complete();

                        MessageBox.Show("You've Successfully Updated new Expence Category", "Success");
                        _UnitOfWork.Dispose();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Select a Category For The Expence", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TxtPaymnt_KeyPress(object sender, KeyPressEventArgs e)
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
