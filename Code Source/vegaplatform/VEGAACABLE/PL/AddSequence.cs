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
    public partial class AddSequence : Form
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int seqID;
        public AddSequence(int id)
        {
            InitializeComponent();
            seqID = id;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add New")
            {
                var ex = _UnitOfWork.Sequence.FirstOrDefault(c => c.Name == txtDesign.Text);
                if (ex == null)
                {
                    Sequence sequence = new Sequence { Name = txtDesign.Text };
                    _UnitOfWork.Sequence.InsertOrUpdate(sequence);
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
                var ex = _UnitOfWork.Sequence.Find(seqID);
                if (ex != null)
                {
                    ex.Name = txtDesign.Text;
                    _UnitOfWork.Sequence.InsertOrUpdate(ex);
                    _UnitOfWork.Complete();
                    MessageBox.Show("You've Successfully Updated the Specified Component", "Success");
                    this.Hide();
                }
            }
        }
    }
}
