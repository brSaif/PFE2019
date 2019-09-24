using System;
using System.Linq;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using VEGAACABLE.PL;

namespace VEGAACABLE
{
    public partial class users : UserControl
    {
        public users()
        {
            InitializeComponent();
        }

        private void users_Load(object sender, EventArgs e)
        {
            RefreshDgvUsers();
            RefreshDgvGroup();
        }

        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var matches = _UnitOfWork.Users.AllUsers()
                        .Where(m => m.FullName.Contains(srch.Text)
                                         || m.Adress.Contains(srch.Text)
                                         || m.Email.Contains(srch.Text)
                                         || m.Phone.ToString().Contains(srch.Text)
                                         || m.Id.ToString().Contains(srch.Text)
                                         || m.Group.Name.ToString().Contains(srch.Text))
                        .Select(m => new
                        {
                            ID = m.Id,
                            Name = m.FullName,
                            UserName = m.UserName,
                            Mobile = m.Phone,
                            Email = m.Email,
                            UserGroup = m.Group.Name,
                            ZIP = m.ZipCode,
                            Adress = m.Adress
                        }).ToList();
                UserGV.DataSource = matches; 
            }
            this.UserGV.Columns[0].Width = 30;
            this.UserGV.Columns[6].Width = 100;
        }

        private void btnAddU_Click(object sender, EventArgs e)
        {
            AddUser m = new AddUser(0);

            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshDgvUsers();
        }

        private void btnUpU_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(UserGV.CurrentRow.Cells[0].Value);
            AddUser m = new AddUser(id);
            try
            {
                m.txtFN.Text = UserGV.CurrentRow.Cells[1].Value.ToString();
                m.txtUN.Text = UserGV.CurrentRow.Cells[2].Value.ToString();
                m.txtP.Text = UserGV.CurrentRow.Cells[3].Value.ToString();
                m.txtE.Text = UserGV.CurrentRow.Cells[4].Value.ToString();
                m.txtA.Text = UserGV.CurrentRow.Cells[7].Value.ToString();
                m.txtZ.Text = UserGV.CurrentRow.Cells[6].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshDgvUsers();
        }

        private void btnDU(object sender, EventArgs e)
        {
            if (UserGV.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Would You Confirm To Delete This User", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        var user = _UnitOfWork.Users.Find(Convert.ToInt32(UserGV.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.Users.Remove(user);
                        _UnitOfWork.Complete();
                    }
                    RefreshDgvUsers(); 
                }
            }
            else
            {
                MessageBox.Show("There is nothing to delete !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnDelG(object sender, EventArgs e)
        {
            if (dgvGroup.RowCount > 0)
            {
                DialogResult msg = MessageBox.Show("Would You Confirm To Delete This Group", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
                    {
                        var c = _UnitOfWork.UGroup.Find(Convert.ToInt32(dgvGroup.CurrentRow.Cells[0].Value.ToString()));
                        _UnitOfWork.UGroup.Remove(c);
                        _UnitOfWork.Complete();
                    }
                }

            }
            else
            {
                MessageBox.Show("There is nothing to delete !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            RefreshDgvGroup();
        }

        private void btnUpdG(object sender, EventArgs e)
        {
            if (dgvGroup.Rows.Count > 0)
            {

                AddUserGroup m = new AddUserGroup();
                m.txtGr.Text = dgvGroup.CurrentRow.Cells[1].Value.ToString();
                m.ShowDialog();

            }
            else
            {
                MessageBox.Show("There is nothing to Update !!!", "Opration Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            RefreshDgvGroup();
        }

        private void btnAddG(object sender, EventArgs e)
        {

            AddUserGroup g = new AddUserGroup();
            g.SetRight.Text = "Add New";
            g.ShowDialog();

            RefreshDgvGroup();
        }

        public void RefreshDgvGroup()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var glist = _UnitOfWork.UGroup.AllGroups()
                .Select(t => new { t.Id, t.Name })
                .ToList();

                if (glist.Any())
                {
                    dgvGroup.DataSource = glist;
                }
            }

        }
        public void RefreshDgvUsers()
        {
            using (var _UnitOfWork = new UnitOfWork(new VegaContext()))
            {
                var m = _UnitOfWork.Users.AllUsers()
                        .Select(c => new
                        {
                            c.Id,
                            c.FullName,
                            c.UserName,
                            c.Phone,
                            c.Email,
                            c.Group.Name,
                            c.ZipCode,
                            c.Adress
                        }).ToList();

                if (m.Any())
                {
                    UserGV.DataSource = m;
                    this.UserGV.Columns[0].Width = 30;
                    this.UserGV.Columns[6].Width = 100;
                } 
            }
        }
    }
}
