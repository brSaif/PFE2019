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
    public partial class AddExpenceCat : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int catID;
        public AddExpenceCat(int Id)
        {
            InitializeComponent();
            catID = Id;
        }

        private void AddExpenceCat_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add New")
            {
                var ex = _UnitOfWork.ExpenceCat.FirstOrDefault(c => c.Name == txtDesignation.Text);
                if (ex == null)
                {
                    ExpenceCat expcat = new ExpenceCat { Name = txtDesignation.Text };
                    _UnitOfWork.ExpenceCat.InsertOrUpdate(expcat);
                    _UnitOfWork.Complete();
                    MessageBox.Show("You've Successfully Added new Expence Category", "Success");
                }
                else
                {
                    MessageBox.Show("There exist an expence category with the same designation", "Failed");
                }
            }
            else
            {
                var ex = _UnitOfWork.ExpenceCat.Find(catID);
                if (ex != null)
                {
                    ex.Name = txtDesignation.Text;
                    _UnitOfWork.ExpenceCat.InsertOrUpdate(ex);
                    _UnitOfWork.Complete();
                    MessageBox.Show("You've Successfully Updated the Specified Expence Category", "Success");
                }
            }

            

            //TO-DO :  refrech datagridview

            _UnitOfWork.Dispose();
            this.Hide();

        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
