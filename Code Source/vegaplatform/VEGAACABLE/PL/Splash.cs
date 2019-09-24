using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEGAACABLE
{
    public partial class Splash : Form
    {
        private Form l = new login();

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
           this.Opacity = 0 ;
            FadeIn(this,20);
            timer1.Start();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                timer1.Stop();
                this.Hide();
                l.Show();
           
        }
    }
}
