using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.PL;
using VEGAACABLE.DAL;
using VEGAACABLE.DAL.Repositories;

namespace VEGAACABLE
{
    public partial class suppliers : UserControl
    {

        public suppliers()
        {
            InitializeComponent();
        }

        private void suppliers_Load(object sender, EventArgs e)
        {
            RefreshSup();
        }

        private void btnAddSup_Click(object sender, EventArgs e)
        {
            AddSupplier m = new AddSupplier();
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshSup();
        }

        private void btnUpSup_Click(object sender, EventArgs e)
        {
            if (dgvSup.RowCount > 0)
            {
                AddSupplier m = new AddSupplier();
                
                try
                {
                    m.lblId.Text = dgvSup.CurrentRow.Cells[0].Value.ToString();
                    m.txtCompany.Text = dgvSup.CurrentRow.Cells[1].Value.ToString();
                    m.txtFirstName.Text = dgvSup.CurrentRow.Cells[2].Value.ToString();
                    m.txtLastName.Text = dgvSup.CurrentRow.Cells[3].Value.ToString();
                    m.txtPhone.Text = dgvSup.CurrentRow.Cells[6].Value.ToString();
                    m.txtEmail.Text = dgvSup.CurrentRow.Cells[5].Value.ToString();
                    m.txtAdress.Text = dgvSup.CurrentRow.Cells[7].Value.ToString();
                    m.btnAdd.Text = "Update";
                    m.ShowDialog();
                    RefreshSup();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            
        }

        private void btnDelSup_Click(object sender, EventArgs e)
        {
            if (dgvSup.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Do You Confirm To Delete This Supplier", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        _UnitOfWork.Supplier.Delete(Convert.ToInt32(dgvSup.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.Complete();
                    }
                    MessageBox.Show("Supplier deleted successfully !!!", "Opration Success", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    RefreshSup(); 
                }
            }
            else
            {
                MessageBox.Show("There is nothing to delete !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void txtSearchSup_TextChange(object sender, EventArgs e)
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var matches = _UnitOfWork.Supplier.AllSuppliers()
                        .Select(c => new { c.Id, c.Company, c.FirstName, c.LastName, c.Category, c.Email, c.Phone, c.Adress })
                        .Where(m => m.Company.Contains(txtSearchSup.Text)
                                         || m.FirstName.Contains(txtSearchSup.Text)
                                         || m.LastName.Contains(txtSearchSup.Text)
                                         || m.Email.Contains(txtSearchSup.Text)
                                         || m.Phone.ToString().Contains(txtSearchSup.Text)
                                         || m.Id.ToString().Contains(txtSearchSup.Text)).ToList();

                dgvSup.DataSource = matches; 
            }
          this.dgvSup.Columns[0].Width = 30;
          this.dgvSup.Columns[7].Width = 170;
        }

        public void RefreshSup()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                dgvSup.DataSource = _UnitOfWork.Supplier.AllSuppliers()
                        .Select(c => new { c.Id, c.Company, c.FirstName, c.LastName, c.Category, c.Email, c.Phone, c.Adress }).ToList(); 
            }
            this.dgvSup.Columns[0].Width = 30;
            this.dgvSup.Columns[7].Width = 170;
        }
    }
}
