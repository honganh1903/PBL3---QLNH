using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace GUI
{
    public partial class frmLoadImage : Form
    {
        public Image img = null;
        PictureBox pic = new PictureBox();
        public frmLoadImage()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (txtURL.Text == "")
            {
                lblThongBao.Text = "Bạn chưa nhập vào URL!";
                lblThongBao.Visible = true;
                Cursor = Cursors.Default;
                return;
            }
            if (CheckForInternetConnection())
            {
                try
                {
                    pic.Load(txtURL.Text);
                    img = pic.Image;
                    Cursor = Cursors.Default;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    lblThongBao.Text = "Địa chỉ URL không dúng!";
                    lblThongBao.Visible = true;
                    Cursor = Cursors.Default;
                    return;
                }
            }
            lblThongBao.Text = "Không có kết nối Internet!";
            lblThongBao.Visible = true;
            Cursor = Cursors.Default;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                DialogResult r = dlg.ShowDialog();

                if (dlg.FileName != null && r != DialogResult.Cancel)
                {
                    pic.Image = null;
                    pic.Image = new Bitmap(dlg.FileName);
                    img = pic.Image;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                if (dlg.FileName == null)
                {
                    return;
                }
            }
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            if (lblThongBao.Visible == true)
                lblThongBao.Visible = false;
        }
    }
}
