using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;
using static System.Convert;

namespace VEGAACABLE
{
    public partial class setProfile : UserControl
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public static int uID ;
        public setProfile(int id)
        {
            uID = id;
            InitializeComponent();
        }

        private void setProfile_Load(object sender, EventArgs e)
        {
            
            var u = _unitOfWork.Users.Find(uID);
            if (u != null)
            {
                txtUsrNm.Text = u.UserName;
                txtFn.Text = u.FullName;
                txtAdr.Text = u.Adress;
                txtMail.Text = u.Email;
                txtPhn.Text = u.Phone.ToString();
                txtZipc.Text = u.ZipCode.ToString();
                img.Image = byteArrayToImage(u.ProfileImage);
            }
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

        private void Img_Click(object sender, EventArgs e)
        {
            var of = new OpenFileDialog
            {
                Title = "Please select photo", Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif", Multiselect = false
            };
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.img.ImageLocation = of.FileName;
            }
            of.Dispose();
        }

        private void BunifuButton3_Click(object sender, EventArgs e)
        {
            var u = _unitOfWork.Users.Find(uID);
            if (u != null)
            {
                u.ProfileImage = imageToByteArray(img.Image);
                u.UserName = txtUsrNm.Text;
                u.FullName = txtFn.Text;
                u.Adress = txtAdr.Text;
                u.ZipCode = ToInt32(txtZipc.Text);
                _unitOfWork.Users.InsertOrUpdate(u);
                _unitOfWork.Complete(); 
            }
        }

        private void BunifuButton2_Click(object sender, EventArgs e)
        {
            var u = _unitOfWork.Users.Find(uID);
            u.Email = txtMail.Text;
            _unitOfWork.Users.InsertOrUpdate(u);
            _unitOfWork.Complete();
        }

        private void BunifuButton4_Click(object sender, EventArgs e)
        {
            var u = _unitOfWork.Users.Find(uID);
            if (u != null )
            {
                if (u.Password == txtOldPass.Text)
                {
                    u.Password = txtNewPass.Text;
                    _unitOfWork.Users.InsertOrUpdate(u);
                    _unitOfWork.Complete();
                }
                else
                {
                    MessageBox.Show("the old pass is wrong", "warnnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void TxtZipc_KeyPress(object sender, KeyPressEventArgs e)
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
    }

}
