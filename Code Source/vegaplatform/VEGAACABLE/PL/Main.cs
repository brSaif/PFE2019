using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;
using VEGAACABLE.PL;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE
{
    public partial class Main : Form
    {
        public static List<string> usrRights;
        public static int uId;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public Home _home;
        public stock _stock;
        public users _users;
        public expences _expence;
        public transactions _transactions;
        public clients _clients;
        public suppliers _suppliers;
        public settings _settings;
        public forbidden503 _Forbidden503 = new forbidden503();
        public Nomenclature _Nomenclature;
        public FabricationOrder _FabricationOrder;


        public Main(int id)
        {
            uId = id;
            _settings = new settings(uId);
            _home = new Home();
            _stock = new stock();
            _users = new users();
            _expence = new expences(uId);
            _transactions = new transactions(uId);
            _clients = new clients();
            _suppliers = new suppliers();
            _Nomenclature = new Nomenclature();
            _FabricationOrder = new FabricationOrder();

            InitializeComponent();


            this.Shown += new System.EventHandler(ScrollBar);
            //this.Load += new System.EventHandler(Main1_Load);
        }

        private void Main1_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
                panel5.Controls.Add(_home);
                panel5.Controls.Add(_settings);
                panel5.Controls.Add(_clients);
                panel5.Controls.Add(_expence);
                panel5.Controls.Add(_stock);
                panel5.Controls.Add(_suppliers);
                panel5.Controls.Add(_transactions);
                panel5.Controls.Add(_FabricationOrder);
                panel5.Controls.Add(_Nomenclature);
                panel5.Controls.Add(_transactions);
                panel5.Controls.Add(_users);
                panel5.Controls.Add(_Forbidden503);
            });

            var u = _unitOfWork.Users.Find(uId);
            usrRights = _unitOfWork.GroupPermission.AllGroupPermissions()
                .Where(c => c.GroupId == u.GroupId)
                .Select(c => c.Permission.Name).ToList();
            lblFulName.Text = u.FullName;
            lblUg.Text = u.Group.Name;
            if (u.ProfileImage != null)
            {
                Img.Image = byteArrayToImage(u.ProfileImage);
            }

            this.Opacity = 0;
            FadeIn(this, 20);
            btnMenu.Image = Properties.Resources.icons8_Menu_50px;
            llg.Visible = false;
            lg.Visible = true;

            if (usrRights.Contains("Dashboard"))
            {
                _home.Show();

            }
            else
            {
                _Forbidden503.Show();
            }

            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            _expence.Hide();
            _stock.Hide();
            _users.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();

            lbldash.Text = "Dashboard";
            btnHome.selected = true;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

        }


        private void btnSettings_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            if (usrRights.Contains("Settings"))
            {
                _settings.Show();
            }
            else
            {
                _Forbidden503.Show();
            }
            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            lbldash.Text = "Settings";

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Suppliers"))
            {
                _suppliers.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            _transactions.Hide();
            _clients.Hide();
            _settings.Hide();
            lbldash.Text = "Suppliers";
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Clients"))
            {
                _clients.Show();
            }
            else
            {
                _Forbidden503.Show();
            }


            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _transactions.Hide();
            _suppliers.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            _settings.Hide();
            lbldash.Text = "Clients";
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Transactions"))
            {
                _transactions.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            lbldash.Text = "Transactions";
        }

        private void btnExpences_Click(object sender, EventArgs e)
        {

            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Expences"))
            {
                _expence.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            lbldash.Text = "Expences";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Users"))
            {
                _users.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _expence.Hide();
            _transactions.Hide();
            _clients.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            _suppliers.Hide();
            _settings.Hide();
            lbldash.Text = "Users Manegement";
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Stock"))
            {
                _stock.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _users.Hide();
            _expence.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            lbldash.Text = "Stock";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;

            if (usrRights.Contains("Dashboard"))
            {
                _home.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            _FabricationOrder.Hide();
            _Nomenclature.Hide();
            lbldash.Text = "Dashboard";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            //Side menu slide-effect
            if (panel2.Width == 222)
            {
                btnMenu.Image = VEGAACABLE.Properties.Resources.icons8_Menu_50px;
                //btnMenu.ImageActive = VEGAACABLE.Properties.Resources.icons8_Menu_50px_2;
                while (panel2.Width > 69)
                {
                    panel2.Width = panel2.Width - 3;
                }
                llg.Visible = false;
                lg.Visible = true;
                dashSide1.Show();
            }
            else if (panel2.Width == 69)
            {
                btnMenu.Image = VEGAACABLE.Properties.Resources.icons8_Delete_50px_2;
                //btnMenu.ImageActive = VEGAACABLE.Properties.Resources.icons8_Delete_50px_1;
                while (panel2.Width < 222)
                {
                    P1.Show();
                    P2.Show();
                    panel2.Width = panel2.Width + 3;
                    indicator.Visible = false;
                    P1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
                    P2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
                }
                indicator.Visible = true;
                llg.Visible = true;
                lg.Visible = false;
                P1.Hide();
                P2.Hide();
                dashSide1.Hide();
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

        private void ScrollBar(object sender, EventArgs e)
        {
            // Enable the default scrollbars first
            // then get the value(s) required.
            panel5.AutoScroll = true;

            // Set the vertical scroll maximum value to be at-par with the flowlayout.
            bunifuVScrollBar1.Maximum = panel5.VerticalScroll.Maximum - 450;
            //bunifuVScrollBar1.Maximum = home1.VerticalScroll.Maximum;

            //You can even change the thumb length.
            bunifuVScrollBar1.ThumbLength = 150;
            // Now disable the default scrollbars.
            panel5.AutoScroll = false;
            //bunifuVScrollBar1.Maximum = panel5.VerticalScroll.Maximum;

        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            // This automatically scrolls the flow-layout position based on the scroll value.
            //panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X);
            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, e.Value);
        }

        private void BtnNomecla_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            if (usrRights.Contains("Nomenclature"))
            {
                _Nomenclature.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            _FabricationOrder.Hide();
            lbldash.Text = "Nomenclature";

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;
        }

        private void BtnFabOrd_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            indicator.Height = ((Control)sender).Height;

            if (usrRights.Contains("FabOrder"))
            {
                _FabricationOrder.Show();
            }
            else
            {
                _Forbidden503.Show();
            }

            _home.Hide();
            _stock.Hide();
            _users.Hide();
            _expence.Hide();
            _transactions.Hide();
            _clients.Hide();
            _suppliers.Hide();
            _settings.Hide();
            _Nomenclature.Hide();
            lbldash.Text = "Fab Orders";

            panel5.AutoScrollPosition = new Point(panel5.AutoScrollPosition.X, 0);
            bunifuVScrollBar1.Value = 0;
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);

            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
