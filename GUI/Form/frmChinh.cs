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
using GUI.UserControls;

namespace GUI
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }
        Task taskLoadUserControl;
        string ucName;

        public void AddControl(string ucname)
        {
            ucName = ucname;
            //Xóa các uc trước khi thêm uc mới vào
            foreach (UserControl uc in pnControls.Controls.OfType<UserControl>())
            {
                pnControls.Controls.Remove(uc);
            }

            taskLoadUserControl = new Task(LoadUserControl);

            taskLoadUserControl.Start();
        }

       

        public void LoadUserControl()
        {   
            pnControls.Invoke(new MethodInvoker(delegate ()
            {
                switch (ucName)
                {
                    case "ucTrangChu":
                        {
                            ucTrangChu ucTC = new ucTrangChu();
                            ucTC.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucTC);
                        }
                        break;
                    case "ucSanPham":
                        {
                            ucQuanLySanPham ucSP = new ucQuanLySanPham();
                            ucSP.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucSP);
                        }
                        break;
                    case "ucNhapSanPham":
                        {
                            ucNhapSanPham ucNSP = new ucNhapSanPham();
                            ucNSP.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucNSP);
                        }
                        break;
                    case "ucBanSanPham":
                        {
                            ucBanSanPham ucBH = new ucBanSanPham();
                            ucBH.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucBH);
                        }
                        break;
                    case "ucNhanVien":
                        {
                            ucNhanVien ucNV = new ucNhanVien();
                            ucNV.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucNV);
                        }
                        break;
                    case "ucKhachHang":
                        {
                            ucKhachHang ucKH = new ucKhachHang();
                            ucKH.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucKH);
                        }
                        break;
                    case "ucThongKe":
                        {
                            ucThongKe ucTL = new ucThongKe();
                            ucTL.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucTL);
                        }
                        break;
                }
            }));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        


        private void AddControlsIntoPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            pnControls.Controls.Clear();
            pnControls.Controls.Add(c);
        }

        private void check_reset(Button button)
        {
            foreach (Control control in panelLeft.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button btn = (Button)control;
                    if (btn.Text != button.Text)
                    {
                        if (btn.BackColor != Color.White)
                        {
                            btn.BackColor = Color.FromArgb(17, 145, 249);
                            btn.ForeColor = Color.White;
                            //btn.Image = (Image)Properties.Resources.ResourceManager.GetObject(btn.AccessibleName + "_blue");
                        }
                        btn.FlatAppearance.MouseDownBackColor = Color.White;
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            timerPanel.Start();
            Cursor = Cursors.Default;
        }

        int PanelWidth;
        bool isCollapsed;

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 8;
                if (panelLeft.Width >= PanelWidth)
                {
                    timerPanel.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 8;
                if (panelLeft.Width <= 64)
                {
                    timerPanel.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {

            if (TaiKhoanBL.Instance.GetTenQuyen(frmDangNhap.Quyen) != "Admin")
            {
                lbQuyen.Text = TaiKhoanBL.Instance.GetTenQuyen(frmDangNhap.Quyen);
                lbTenNV.Text = NhanVienBL.Instance.GetTenNhanVien(frmDangNhap.TenDangNhap);
                btnSanPham.Enabled = false;
                btnTrangChu.Enabled = false;
                btnNhapSanPham.Enabled = false;
                btnBanSanPham.PerformClick();
            }
            else
            {
                lbQuyen.Text = TaiKhoanBL.Instance.GetTenQuyen(frmDangNhap.Quyen);
                lbTenNV.Text = NhanVienBL.Instance.GetTenNhanVien(frmDangNhap.TenDangNhap);
                btnThongKe.PerformClick();
            }
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnTrangChu);
            if (btnTrangChu.ForeColor == Color.White)
            {
                btnTrangChu.ForeColor = Color.FromArgb(255, 255, 254);
                btnTrangChu.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnTrangChu);
                AddControl("ucTrangChu");
            }
            else
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            if (btnTrangChu.ForeColor == Color.White)
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.White;
            }


            Cursor = Cursors.Default;
        }
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnBanSanPham);
            if (btnBanSanPham.ForeColor == Color.White)
            {
                btnBanSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnBanSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnBanSanPham);
                AddControl("ucBanSanPham");
            }
            if (btnBanSanPham.ForeColor == Color.White)
            {
                btnBanSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnBanSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnSanPham);
            if (btnSanPham.ForeColor == Color.White)
            {
                btnSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnSanPham);
                AddControl("ucSanPham");
            }
            if (btnSanPham.ForeColor == Color.White)
            {
                btnSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnNhanVien);
            if (btnNhanVien.ForeColor == Color.White)
            {
                btnNhanVien.ForeColor = Color.FromArgb(255, 255, 254);
                btnNhanVien.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnNhanVien);
                AddControl("ucNhanVien");
            }
            if (btnNhanVien.ForeColor == Color.White)
            {
                btnNhanVien.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnNhanVien.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnKhachHang);
            if (btnKhachHang.ForeColor == Color.White)
            {
                btnKhachHang.ForeColor = Color.FromArgb(255, 255, 254);
                btnKhachHang.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnKhachHang);
                AddControl("ucKhachHang");
            }
            if (btnKhachHang.ForeColor == Color.White)
            {
                btnKhachHang.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnKhachHang.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnThongKe);
            if (btnThongKe.ForeColor == Color.White)
            {
                btnThongKe.ForeColor = Color.FromArgb(255, 255, 254);
                btnThongKe.BackColor = Color.FromArgb(8, 133, 204);
                //btnThongKe.Image = Properties.Resources.thietlap_black;

                check_reset(btnThongKe);
                AddControl("ucThietLap");
            }
            if (btnThongKe.ForeColor == Color.White)
            {
                btnThongKe.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnThongKe.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }
        private void btnNhapSanPham_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnNhapSanPham);
            if (btnNhapSanPham.ForeColor == Color.White)
            {
                btnNhapSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnNhapSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnNhapSanPham);
                AddControl("ucNhapSanPham");
            }
            if (btnNhapSanPham.ForeColor == Color.White)
            {
                btnNhapSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnNhapSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

    }
}
