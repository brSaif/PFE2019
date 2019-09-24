using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using VEGAACABLE.PL;

namespace VEGAACABLE
{
    public partial class clients : UserControl
    {

        public clients()
        {
            InitializeComponent();
        }

        private void clients_Load(object sender, EventArgs e)
        {
            RefreshClientDGV();
        }


        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var matches = _UnitOfWork.Clients.AllClients()
                        .Select(c => new { c.Id, c.Company, c.FirstName, c.LastName, c.Phone, c.Email, c.Adress })
                        .Where(m => m.Company.Contains(srch.Text)
                                    || m.FirstName.Contains(srch.Text)
                                    || m.LastName.Contains(srch.Text)
                                    || m.Email.Contains(srch.Text)
                                    || m.Phone.ToString().Contains(srch.Text)
                                    || m.Id.ToString().Contains(srch.Text)).ToList();
                dgvUser.DataSource = matches; 
            }
            this.dgvUser.Columns[0].Width = 35;

        }

        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            AddClient m = new AddClient();
            m.ShowDialog();
            try
            {
                m.btnAdd.Text = "Add New";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshClientDGV();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            AddClient m = new AddClient();
            
            try
            {
                m.txtCompany.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
                m.txtFirstName.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
                m.txtLastName.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
                m.txtPhone.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();
                m.txtAdress.Text = dgvUser.CurrentRow.Cells[6].Value.ToString();
                m.txtEmail.Text = dgvUser.CurrentRow.Cells[5].Value.ToString();
                m.lblId.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();
                RefreshClientDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (dgvUser.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Do You Confirm To Delete This Client", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        _UnitOfWork.Clients.Delete(Convert.ToInt32(dgvUser.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.Complete();
                    } 
                }
                RefreshClientDGV();
            }
            else
            {
                MessageBox.Show("There is nothing to delete !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        public void RefreshClientDGV()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var list = _UnitOfWork.Clients.AllClients()
                        .Select(c => new { c.Id, c.Company, c.FirstName, c.LastName, c.Phone, c.Email, c.Adress }).ToList();
                if (list.Any())
                {
                    dgvUser.DataSource = list;
                } 
            }
            this.dgvUser.Columns[0].Width = 35;
        }
    }
}
