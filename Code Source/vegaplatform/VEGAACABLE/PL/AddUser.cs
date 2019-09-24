using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;
using VEGAACABLE.DAL.Repositories;
using Task = System.Threading.Tasks.Task;

namespace VEGAACABLE.PL
{
    public partial class AddUser : Form
    {
        public readonly UnitOfWork _UnitOfWork = new UnitOfWork(new VegaContext());
        public static int usrId;

        public AddUser(int id)
        {
            usrId = id;
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            FadeIn(this, 10);
            var groups = _UnitOfWork.UGroup.AllGroups()
                .Select(t => t.Name).ToList();

            foreach (object t in groups)
            {
                dwnGroups.Items.Add(t);
            }

            dwnGroups.selectedIndex = 0;

            if (btnAdd.Text == "Update")
            {
                var user = _UnitOfWork.Users.Find(usrId);
                pictureBox1.Image = byteArrayToImage(user.ProfileImage);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Update")
                {

                    var user = _UnitOfWork.Users.Find(usrId);

                    user.FullName = txtFN.Text;
                    user.UserName = txtUN.Text;
                    user.Email = txtE.Text;
                    user.Phone = Convert.ToInt32(txtP.Text);
                    user.Adress = txtA.Text;
                    user.ZipCode = Convert.ToInt32(txtZ.Text);
                    user.GroupId = dwnGroups.selectedIndex + 1;
                    _UnitOfWork.Users.InsertOrUpdate(user);
                    _UnitOfWork.Complete();

                    this.Hide();

                }

                else
                {

                    var User = new User
                    {
                        FullName = txtFN.Text,
                        UserName = txtUN.Text,
                        Email = txtE.Text,
                        Phone = Convert.ToInt32(txtP.Text),
                        Adress = txtA.Text,
                        ZipCode = Convert.ToInt32(txtZ.Text),
                        ProfileImage = imageToByteArray(pictureBox1.Image),
                        Password = "changeme",
                        GroupId = dwnGroups.selectedIndex + 1,
                    };

                    _UnitOfWork.Users.InsertOrUpdate(User);
                    _UnitOfWork.Complete();
                    
                    this.Hide();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                                           && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var of = new OpenFileDialog
            {
                Title = "Please select photo",
                Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif",
                Multiselect = false
            };
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.ImageLocation = of.FileName;
            }
            of.Dispose();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);

            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
