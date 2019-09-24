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
    public partial class AddUserGroup : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static string ugroup = "";
        public static int ugId ;
        public AddUserGroup()
        {
            InitializeComponent();
        }

        private void AddUserGroup_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.DataSource = _UnitOfWork.Permission.AllPermissions().Select(c => c.Name).ToList();
            if (SetRight.Text == "Update")
            {
                ugroup = txtGr.Text;
                ugId = _UnitOfWork.UGroup.FirstOrDefault(c => c.Name == ugroup).Id;
                //load the current rights
                var permissions = _UnitOfWork.GroupPermission.AllGroupPermissions()
                    .Where(c => c.Group.Name == ugroup);

                if (permissions.Any())
                {
                    foreach (var t in permissions)
                    {
                        dgvPermission.Rows.Add(t.PermissionId, t.Permission.Name);
                    }
                } 
            }
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SetRight_Click(object sender, EventArgs e)
        {
            
            if (txtGr != null && dgvPermission.Rows.Count > 0)
            {
                if (SetRight.Text == "Add New")
                {
                    //check there isn't another group with the same name

                    var group = _UnitOfWork.UGroup
                        .AllGroups().Count(c => c.Name == txtGr.Text);
                    if (group == 0)
                    {
                        //create new group first
                        UGroup gr = new UGroup { Name = txtGr.Text };
                        _UnitOfWork.UGroup.InsertOrUpdate(gr);
                        foreach (DataGridViewRow r in dgvPermission.Rows)
                        {
                            // foreach row we insert the hidden permission Id and newly created user group
                            UGroupPermission ugp = new UGroupPermission { Group = gr, PermissionId = Convert.ToInt32(r.Cells[0].Value) };
                            _UnitOfWork.GroupPermission.InsertOrUpdate(ugp);
                        }

                        _UnitOfWork.Complete();
                        MessageBox.Show("You've Successfully created a new user Group and set its rights", "Success");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("this group already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Hide();
                    }
                }
                else if (SetRight.Text == "Set Rights")
                {
                    try
                    {
                        var grp = _UnitOfWork.UGroup.Find(ugId);

                        var f = _UnitOfWork.GroupPermission.AllGroupPermissions().Where(c => c.GroupId == grp.Id);

                        _UnitOfWork.GroupPermission.RemoveRange(f);
                        
                        grp.Name = txtGr.Text;

                        _UnitOfWork.UGroup.InsertOrUpdate(grp);

                        foreach (DataGridViewRow r in dgvPermission.Rows)
                        {
                            UGroupPermission ugp = new UGroupPermission { GroupId = grp.Id, PermissionId = Convert.ToInt32(r.Cells[0].Value) };
                            _UnitOfWork.GroupPermission.InsertOrUpdate(ugp);
                        }

                        _UnitOfWork.Complete();
                        MessageBox.Show("You've Successfully Updated this user group rights", "Success");
                        
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hint : Check that your group name field isn't blank and it has at least one right"
                    , "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnAddG_Click(object sender, EventArgs e)
        {
            int m = 0;
            foreach (DataGridViewRow t in dgvPermission.Rows)
            {
                if (t.Cells[1].Value.ToString() == bunifuDropdown1.SelectedValue.ToString())
                {
                    m++;
                }
            }
            if (m == 0)
            {
                var permission = _UnitOfWork.Permission
                    .FirstOrDefault(c => c.Name == bunifuDropdown1.SelectedValue.ToString());
                dgvPermission.Rows.Add(permission.Id, permission.Name); 
            }
            else
            {
                MessageBox.Show("Already Added Permission", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvPermission_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPermission.Rows.Remove(dgvPermission.CurrentRow);
        }

    }
}
