
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;
using VEGAACABLE.PL;

namespace VEGAACABLE
{
    public partial class expences : UserControl
    {
        //public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int usrID;
        public expences(int id)
        {
            InitializeComponent();
            usrID = id;
        }

        private void Expences_Load(object sender, EventArgs e)
        {
            RefreshDgvExpence();
            RefreshDgvCat();
        }

        private void BtnAddExp_Click(object sender, EventArgs e)
        {
            
            AddExpence m = new AddExpence(0,usrID);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            //refresh DataGridView
            RefreshDgvExpence();
        }

        private void BtnUpdExp_Click(object sender, EventArgs e)
        {
            if (dgvExpence.Rows.Count > 0)
            {
                var expenceId = Convert.ToInt32(dgvExpence.CurrentRow.Cells[0].Value);
                AddExpence m = new AddExpence(expenceId,usrID);
                m.txtPaymnt.Text = dgvExpence.CurrentRow.Cells[2].Value.ToString();
                m.txtDescrip.Text = dgvExpence.CurrentRow.Cells[5].Value.ToString();
                m.dwnCategories.SelectedItem(dgvExpence.CurrentRow.Cells[1].Value.ToString());
                m.btnAdd.Text = "Update";
                m.ShowDialog();

            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            RefreshDgvExpence();
        }

        private void BtnDelExp_Click(object sender, EventArgs e)
        {
            if (dgvExpence.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Would You Confirm This Expence", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        var d = _UnitOfWork.Expence.Find(Convert.ToInt32(dgvExpence.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.Expence.Remove(d);
                        _UnitOfWork.Complete();
                    }
                }

            }
            RefreshDgvExpence();
        }

        private void TxtSearchExpence_TextChange(object sender, EventArgs e)
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var matches = _UnitOfWork.Expence.AllExpences()
                       .Where(m => m.Payment.ToString().Contains(txtSearchExpence.Text)
                                   || m.CreatedDate.ToString().Contains(txtSearchExpence.Text)
                                   || m.Description.Contains(txtSearchExpence.Text)
                                   || m.User.UserName.Contains(txtSearchExpence.Text)
                                   || m.ExpenceCat.Name.ToString().Contains(txtSearchExpence.Text)
                                   || m.Id.ToString().Contains(txtSearchExpence.Text))
                       .Select(c => new
                       {
                           c.Id,
                           Category = c.ExpenceCat.Name,
                           c.Payment,
                           Date = c.CreatedDate.Date,
                           CreatedBy = c.User.UserName,
                           c.Description
                       }).ToList();
                dgvExpence.DataSource = matches; 
            }
        }

        private void BtnAddCat_Click(object sender, EventArgs e)
        {
            AddExpenceCat m = new AddExpenceCat(0);
            
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshDgvCat();
        }

        private void BtnUpdCat_Click(object sender, EventArgs e)
        {
            if (dgvEpenceCat.Rows.Count > 0)
            {
                var CatId = Convert.ToInt32(dgvEpenceCat.CurrentRow.Cells[0].Value);
                AddExpenceCat m = new AddExpenceCat(CatId);
                m.txtDesignation.Text = dgvEpenceCat.CurrentRow.Cells[1].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();

            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            RefreshDgvCat();
        }

        private void BtnDelCat_Click(object sender, EventArgs e)
        {
            if (dgvEpenceCat.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Would You Confirm This Expence", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        var t = _UnitOfWork.ExpenceCat.Find(Convert.ToInt32(dgvEpenceCat.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.ExpenceCat.Remove(t);
                        _UnitOfWork.Complete();
                    }
                }

            }
            //refrech DGV
            RefreshDgvCat();
        }

        public void RefreshDgvCat()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var expenceCatList = _UnitOfWork.ExpenceCat.AllExpenceCats()
                        .Select(c => new { c.Id, c.Name }).ToList();

                if (expenceCatList.Any())
                {
                    dgvEpenceCat.DataSource = expenceCatList;
                    dgvEpenceCat.Columns[0].Width = 40;
                }
            }
        }

        public void RefreshDgvExpence()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var expenceList = _UnitOfWork.Expence.AllExpences()
                       .Select(c => new
                       {
                           c.Id,
                           Category = c.ExpenceCat.Name,
                           c.Payment,
                           Date = c.CreatedDate.Date,
                           CreatedBy = c.User.UserName,
                           c.Description
                       }).ToList();
                if (expenceList.Any())
                {
                    dgvExpence.DataSource = expenceList;
                    dgvExpence.Columns[0].Width = 25;
                } 
            }
        }
    }
}
