using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEGAACABLE
{
    public partial class settings : UserControl
    {
        public setDatabase _setDatabase = new setDatabase();
        public setProfile _setProfile ;
        public settings(int id )
        {
            _setProfile = new setProfile(id);
            InitializeComponent();
        }



        private void setprofile_Click(object sender, EventArgs e)
        {
            _setProfile.Show();
            _setDatabase.Hide();
        }

        private void setdata_Click(object sender, EventArgs e)
        {
            _setDatabase.Show();
            _setProfile.Hide();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(_setProfile);
            panel1.Controls.Add(_setDatabase);
            _setDatabase.Location = new System.Drawing.Point(16, 41);
            _setProfile.Location = new System.Drawing.Point(16, 41);
            _setProfile.Show();
        }
    }
}
