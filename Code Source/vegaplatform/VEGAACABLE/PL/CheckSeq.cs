using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEGAACABLE.PL
{
    public partial class CheckSeq : UserControl
    {
        public CheckSeq()
        {
            InitializeComponent();
        }

        private void S2_Click(object sender, EventArgs e)
        {
            S2.Checked = true;
            S3.Checked = false;
        }

        private void S3_Click(object sender, EventArgs e)
        {
            if (S3.Checked == true)
            {
                S2.Checked = true;
            }
        }
    }
}
