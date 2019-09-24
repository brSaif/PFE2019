using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;
using Component = VEGAACABLE.BL.Domain.Component;

namespace VEGAACABLE.PL
{
    public partial class AddComponent : Form
    {
        private readonly  UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int compID;
        public AddComponent(int id)
        {
            InitializeComponent();
            compID = id;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add New")
            {
                var ex = _UnitOfWork.Component.FirstOrDefault(c => c.Name == txtDesign.Text);
                if (ex == null)
                {
                    Component component = new Component { Name = txtDesign.Text };
                    _UnitOfWork.Component.InsertOrUpdate(component);
                    _UnitOfWork.Complete();
                    MessageBox.Show("You've Successfully Added new Component", "Success");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("There exist a Component with the same designation", "Failed");
                }
            }
            else
            {
                var ex = _UnitOfWork.Component.Find(compID);
                if (ex != null)
                {
                    ex.Name = txtDesign.Text;
                    _UnitOfWork.Component.InsertOrUpdate(ex);
                    _UnitOfWork.Complete();
                    MessageBox.Show("You've Successfully Updated the Specified Component", "Success");
                }
                this.Hide();
            }
            
        }
    }
}
