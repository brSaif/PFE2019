using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class CheckFO : Form
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public static int FOid;
        public CheckFO(int id)
        {
            InitializeComponent();
            FOid = id;
        }

        private void BunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            // This automatically scrolls the flow-layout position based on the scroll value.
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.Value);
        }

        private void CheckFO_Shown(object sender, EventArgs e)
        {
            // Enable the default scrollbars first
            // then get the value(s) required.
            flowLayoutPanel1.AutoScroll = true;

            // Set the vertical scroll maximum value to be at-par with the flowlayout.
            bunifuVScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
            bunifuVScrollBar1.ThumbLength = 100;
            // Now disable the default scrollbars.
            //You can even change the thumb length.
            flowLayoutPanel1.AutoScroll = false;
        }

        private void BunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Would You Like To Confirm The Operation ?", "Warning"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (R == DialogResult.Yes)
            {
                foreach (CheckSeq cs in flowLayoutPanel1.Controls)
                {
                    var checkSeqElement = _unitOfWork.ProgressionChecks
                        .SingleOrDefault(c => c.OFID == FOid && c.Sequence.Name == cs.txtSeq.Text);

                    if (cs.S2.Checked == true && cs.S3.Checked == false)
                    {
                        checkSeqElement.Progress = ProgressionCheck.Progression.InProgress;
                    }
                    else if (cs.S3.Checked == true)
                    {
                        checkSeqElement.Progress = ProgressionCheck.Progression.Finished;
                    }

                    _unitOfWork.ProgressionChecks.InsertOrUpdate(checkSeqElement);
                }

                _unitOfWork.Complete();
                this.Close();
            }
        }

        private void CheckFO_Load(object sender, EventArgs e)
        {
            FadeIn(this,80);
            var SeqList = _unitOfWork.ProgressionChecks.AllProgressionChecks(FOid);
            foreach (var t in SeqList)
            {
                CheckSeq cs = new CheckSeq();
                flowLayoutPanel1.Controls.Add(cs);
                cs.txtSeq.Text = t.Sequence.Name;
                if (t.Progress == ProgressionCheck.Progression.NotStarted)
                {
                    cs.S2.Checked = false;
                    cs.S3.Checked = false;
                }
                else if (t.Progress == ProgressionCheck.Progression.InProgress)
                {
                    cs.S2.Checked = true;
                    cs.S2.Enabled = false;
                    cs.S3.Checked = false;
                }
                else if (t.Progress == ProgressionCheck.Progression.Finished)
                {
                    cs.S2.Checked = true;
                    cs.S3.Checked = true;
                    cs.S2.Enabled = false;
                    cs.S3.Enabled = false;
                }
            }

        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

    }
}
