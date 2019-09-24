using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;

namespace VEGAACABLE
{
    public partial class stock : UserControl
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public stock()
        {
            InitializeComponent();
        }

        private void stock_Load(object sender, EventArgs e)
        {
            RefrechDgvRm();
        }

        public void RefrechDgvRm()
        {
            var rmList = _unitOfWork.RawMaterials.AllRawMaterials()
                .Select(c => new
                {
                    c.ID,
                    Designation = c.Composant.Name,
                    c.RefNbr,
                    c.Mass,
                    c.Lot,
                    ImpDate = c.ImpDate.Date,
                    c.Status,
                    CreatedBy = c.User.UserName,
                    UpDate = c.UpDate.Date
                }).ToList();
            dgvRawMterial.DataSource = rmList;
            dgvRawMterial.Columns[0].Width = 25;
        }

        private void TxtSearch_TextChange(object sender, EventArgs e)
        {
            var rmList = _unitOfWork.RawMaterials.AllRawMaterials()
                .Where(c => c.ID.ToString().Contains(txtSearch.Text)
                || c.Composant.Name.Contains(txtSearch.Text)
                || c.RefNbr.Contains(txtSearch.Text)
                || c.Mass.ToString().Contains(txtSearch.Text)
                || c.Lot.Contains(txtSearch.Text)
                || c.ImpDate.ToString().Contains(txtSearch.Text)
                || c.UpDate.ToString().Contains(txtSearch.Text)
                || c.User.UserName.Contains(txtSearch.Text)
                || c.Status.ToString().Contains(txtSearch.Text)
                )
                .Select(c => new
                {
                    c.ID,
                    Designation = c.Composant.Name,
                    c.RefNbr,
                    c.Mass,
                    c.Lot,
                    ImpDate = c.ImpDate.Date,
                    c.Status,
                    CreatedBy = c.User.UserName,
                    UpDate = c.UpDate.Date
                }).ToList();
            dgvRawMterial.DataSource = rmList;
            dgvRawMterial.Columns[0].Width = 25;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (dgvRawMterial.RowCount > 0)
            {
                var d = _unitOfWork.RawMaterials.Find(Convert.ToInt32(dgvRawMterial.CurrentRow.Cells[0].Value.ToString()));
                if (d.Status == RawMaterial.RMStatus.OutOfStock)
                {
                    DialogResult rm =
                        MessageBox.Show("This product is out of stock Do You Want To Remove It From The Records",
                            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rm == DialogResult.Yes)
                    {
                        _unitOfWork.RawMaterials.Delete(d.ID);
                    }
                }
                else
                {
                    MessageBox.Show("You Can't Delete This Product Untill Its Out Of Stock",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                RefrechDgvRm();
            }
        }
    }
}
