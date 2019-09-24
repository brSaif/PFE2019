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
using VEGAACABLE.BL;
using Task = System.Threading.Tasks.Task;
using VEGAACABLE.PL;

namespace VEGAACABLE
{
    public partial class login : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public login()
        {
            InitializeComponent();
        }

        private void logreg_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);
            
        }
        
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var s = _UnitOfWork.Users.SingleOrDefault(c => c.UserName == txtName.Text || c.Email == txtName.Text && c.Password == txtPass.Text);

            if (s != null)
            {
                
                Form m = new Main(s.Id);
                this.Hide();
                m.Show();
                _UnitOfWork.Dispose();
            }
            else if (s == null)
            {
                MessageBox.Show("Wrong Combination User Name Password ");
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

        private void Lbl3_Click(object sender, EventArgs e)
        {
            RemoteServerConfig m = new RemoteServerConfig();
            m.ShowDialog();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConx.PerformClick();
            }
        }

        //private async void FadeOut(Form o, int interval = 80)
        //{
        //    //Object is fully visible. Fade it out
        //    while (o.Opacity > 0.0)
        //    {
        //        await Task.Delay(interval);
        //        o.Opacity -= 0.05;
        //    }
        //    o.Opacity = 0; //make fully invisible 
        //    this.Hide();
        //}

    }
}
