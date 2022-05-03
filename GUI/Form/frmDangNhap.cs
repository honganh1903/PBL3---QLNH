using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static int Quyen;
        public static int TenDangNhap;
        private void frmDangNhap_Load(object sender, EventArgs e)
        {


            timer1.Start();
            timer2.Start();
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Nhập vào tên đăng nhập")
                txtTenDangNhap.Text = "";
            txtTenDangNhap.ForeColor = Color.Black;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            XuLyDangNhap();
        }
        private void XuLyDangNhap()
        {
            Cursor = Cursors.AppStarting;
            Cursor = Cursors.AppStarting;
            if (TaiKhoanBL.Instance.CheckLogin(txtTenDangNhap.Text, txtMatKhau.Text) == true)
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 100, 0);
                TenDangNhap = int.Parse(txtTenDangNhap.Text);
                Quyen = TaiKhoanBL.Instance.GetMaQuyen(int.Parse(txtTenDangNhap.Text));
                txtMatKhau.Text = "";
                txtTenDangNhap.Text = "";
                Cursor = Cursors.Default;
                this.Alert("Đăng nhập thành công...", frmPopupNotification.enmType.Success);
                frmChinh frm = new frmChinh();
                frm.Show();
                this.Hide();
            }
            else
            {
                Cursor = Cursors.Default;
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng!\nVui lòng nhập lại...";
                frm.Show();
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
            {
                btnShowPass.ImageIndex = 1;
                txtMatKhau.Focus();
            }
            else
            {
                btnShowPass.ImageIndex = 0;
                txtMatKhau.Focus();
            }
            if (txtMatKhau.PasswordChar == '●')
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '●';
            }
        }

        private void btnShowPass_MouseHover(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
                toolTip1.Show("Ẩn mật khẩu", btnShowPass);
            else
                toolTip1.Show("Hiện mật khẩu", btnShowPass);
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.PasswordChar == '●')
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '●';
            if (txtTenDangNhap.Text != "" && txtMatKhau.PasswordChar == '●')
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Nhập vào mật khẩu")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }
    }
}
