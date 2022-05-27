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
using DTO;
using GUI;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace GUI.UserControls
{
    public partial class ucBanSanPham : UserControl
    {
        public ucBanSanPham()
        {
            InitializeComponent();
        }
        bool hd = false;
        public static int SOHD = 0;
        public static decimal ThanhTien = 0;

        private void ucBanSanPham_Load(object sender, EventArgs e)
        {
            LoadCboLocLoaiSP();
            LoadCboLocNCC();
            LoadDanhSachSanPhamTheoBoLoc(1);
        }
        private void LoadCboLocNCC()
        {
            DataTable dt = NCCBL.Instance.GetDanhSachNCC();
            DataRow dr = dt.NewRow();
            dr["Mã NCC"] = "-1";
            dr["Tên NCC"] = "Tất cả";
            dt.Rows.Add(dr);
            cboLocNCC.DataSource = dt;
            cboLocNCC.DisplayMember = "Tên NCC";
            cboLocNCC.ValueMember = "Mã NCC";
            cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1;
        }

        private void LoadCboLocLoaiSP()
        {
            DataTable dt = LoaiSanPhamBL.Instance.GetDanhSachLoaiSanPham();
            DataRow dr = dt.NewRow();
            dr["Mã Loại SP"] = "-1";
            dr["Tên Loại SP"] = "Tất cả";
            dt.Rows.Add(dr);
            cboLocLoaiSP.DataSource = dt;
            cboLocLoaiSP.DisplayMember = "Tên Loại SP";
            cboLocLoaiSP.ValueMember = "Mã Loại SP";
            cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1;
        }
        int sumpage = 0;
        private void LoadDanhSachSanPhamTheoBoLoc(int numpage)
        {
            flowLayoutPanelSanPham.Controls.Clear();
            DataTable dt = SanPhamBL.Instance.GetDanhSachSanPhamTheoBoLoc(txtTenSP.Text.Trim(), cboLocLoaiSP.SelectedValue.ToString().Trim(), cboLocNCC.SelectedValue.ToString().Trim());

            int soDongTrenTrang = 8;
            int soTrang = dt.Rows.Count / soDongTrenTrang;
            if (dt.Rows.Count % soDongTrenTrang != 0)
            {
                soTrang += 1;
            }
            if (soTrang == 0)
            {
                sumpage = 0;
                lblPageNumber.Text = "0/" + sumpage;
            }
            else
            {
                sumpage = soTrang;
                lblPageNumber.Text = "1/" + sumpage;
            }

            int k = 0;
            int j = 0;
            //dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                if (k >= (numpage * 8 - 8))
                {
                    j++;
                    if (j > 8)
                    {
                        row.Delete();
                        continue;
                    }
                    continue;
                }
                row.Delete();
                k++;
            }
            dt.AcceptChanges();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ucSanPham sp = new ucSanPham();
                sp.spDTO.MaSP = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                sp.spDTO.TenSP = dt.Rows[i].ItemArray[1].ToString();
                sp.spDTO.MaLoaiSP = dt.Rows[i].ItemArray[2].ToString();
                sp.spDTO.DVT = dt.Rows[i].ItemArray[3].ToString();
                sp.spDTO.SoLuong = int.Parse(dt.Rows[i].ItemArray[4].ToString());
                sp.spDTO.GiaBan = decimal.Parse(dt.Rows[i].ItemArray[6].ToString());
                sp.spDTO.KhuyenMai = int.Parse(dt.Rows[i].ItemArray[7].ToString());
                sp.spDTO.HinhAnh = (byte[])dt.Rows[i].ItemArray[8];
                MemoryStream ms = new MemoryStream(sp.spDTO.HinhAnh);
                sp.picSP.Image = Image.FromStream(ms);

                sp.lblTenSP.Text = sp.spDTO.TenSP;
                if (sp.spDTO.KhuyenMai == 0)
                {
                    sp.lblGiaKM.Text = "Giá: " + Convert(sp.spDTO.GiaBan) + " ₫";
                    sp.lblGiaGoc.Visible = false;
                    sp.pictureBox2.Visible = false;
                    sp.panel1.Visible = false;
                }
                else
                {
                    sp.lblKM.Text = "-" + sp.spDTO.KhuyenMai + "%";
                    sp.lblGiaGoc.Text = Convert(sp.spDTO.GiaBan) + " ₫";
                    sp.spDTO.GiaBan = sp.spDTO.GiaBan - ((sp.spDTO.GiaBan * sp.spDTO.KhuyenMai) / 100);
                    sp.lblGiaKM.Text = "Giá: " + Convert(sp.spDTO.GiaBan - (sp.spDTO.GiaBan * sp.spDTO.KhuyenMai) / 100) + " ₫";
                    sp.pictureBox2.Click += PictureBox2_Click;
                }
                if (sp.spDTO.SoLuong <= 0)
                {
                    sp.lblSanCo.Text = "Hết hàng!";
                }
                else
                    sp.lblSanCo.Text = "Sẵn có: " + sp.spDTO.SoLuong.ToString() + " " + sp.spDTO.DVT;
                sp.lblGiaGoc.Font = new Font("UTM Avo", 10, FontStyle.Strikeout);
                sp.Click += Sp_Click;
                sp.lblGiaGoc.Click += LblGiaGoc_Click;
                sp.lblGiaKM.Click += LblGiaKM_Click;
                sp.lblKM.Click += LblKM_Click;
                sp.lblTenSP.Click += LblTenSP_Click;
                sp.panel1.Click += Panel1_Click;
                sp.picSP.Click += PicSP_Click;
                sp.pictureBox2.Click += PictureBox2_Click;

                sp.KeyDown += Sp_KeyDown;
                sp.lblGiaGoc.KeyDown += Sp_KeyDown;
                sp.lblGiaKM.KeyDown += Sp_KeyDown;
                sp.lblKM.KeyDown += Sp_KeyDown;
                sp.lblTenSP.KeyDown += Sp_KeyDown;
                sp.panel1.KeyDown += Sp_KeyDown;
                sp.picSP.KeyDown += Sp_KeyDown;
                sp.pictureBox2.KeyDown += Sp_KeyDown;
                flowLayoutPanelSanPham.Controls.Add(sp);
            }
        }
        private void ThemCTDH()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvCTHD.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvCTHD.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            if (CTHDBL.Instance.ThemCTHD(dt, SOHD, decimal.Parse(ThanhTien.ToString())))
            {
                CapNhatSoLuong();
                SOHD_Report = SOHD;
                CapNhatTienKhachHang();
                ClearThongTinHD();
                SOHD = 0;
            }
        }
        private void CapNhatSoLuong()
        {
            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                DataGridViewRow r = dgvCTHD.Rows[i];
                SanPhamBL.Instance.CapNhatSoLuongKhiBanHang(int.Parse(r.Cells[0].Value.ToString()), int.Parse(r.Cells[4].Value.ToString()));
            }
        }

        private void ClearThongTinHD()
        {
            dgvCTHD.Rows.Clear();
            lblTongTien.Text = "0";
            txtTienKHTra.Text = "";
            txtTienThua.Text = "";
            txtSDT.Text = "";
            txtTenKH.Text = "";
            btnThanhToan.BackColor = Color.Gray;
            btnHuy.BackColor = Color.Gray;
        }

        private void CapNhatTienKhachHang()
        {
            HoaDonBL.Instance.CapNhatSoLuongTienKhachHang(SOHD_Report, decimal.Parse(txtTienKHTra.Text), decimal.Parse(txtTienThua.Text));
        }

        public static int SOHD_Report = 0;
        private void ThanhToanF9()
        {
            btnThanhToan.PerformClick();
        }
        private void HuyF12()
        {
            btnHuy.PerformClick();
        }
        private void Sp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }
        private string Convert(int gia)
        {
            string giaban = gia.ToString();
            string result = "";
            int d = 0;
            for (int i = giaban.Length - 1; i >= 0; i--)
            {
                d++;
                result += giaban[i];
                if (d == 3 && i != 0)
                {
                    result += ',';
                    d = 0;
                }
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void Sp_Click(object sender, EventArgs e)
        {

        }
        int makh = 0;
        private void ThemHoaDon()
        {
            HoaDonDTO hddTO = new HoaDonDTO();
            if (txtTenKH.Text == "")
                hddTO.MaKH = 1;
            else
                hddTO.MaKH = makh;
            hddTO.MaNV = frmDangNhap.TenDangNhap;
            hddTO.NgayLap = DateTime.Now;
            hddTO.ThanhTien = 0;
            hddTO.DaThanhToan = false;
            bool s = HoaDonBL.Instance.ThemHoaDon(hddTO);
            SOHD = HoaDonBL.Instance.GetSOHDMAX();

            btnHuy.BackColor = Color.OrangeRed;

            this.Alert("Đã tạo đơn hàng...", frmPopupNotification.enmType.Info);

            txtSDT.Enabled = false;
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        private void LoadTongHoaDon()
        {
            decimal tong = 0;
            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                tong += decimal.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString());
            }
            ThanhTien = tong;
            lblTongTien.Text = Convert(tong) + " ₫";
            if (txtTienKHTra.Text == "")
                return;
            if (tong < decimal.Parse(txtTienKHTra.Text))
            {
                txtTienThua.Text = Convert((Math.Abs(ThanhTien - decimal.Parse(txtTienKHTra.Text)))) + "";
                btnThanhToan.BackColor = Color.Green;
            }
            else
            {
                txtTienThua.Text = "Không đủ";
                btnThanhToan.BackColor = Color.Gray;
            }

        }
        private string Convert(decimal gia)
        {
            string giaban = gia.ToString();
            string result = "";
            int d = 0;
            for (int i = giaban.Length - 1; i >= 0; i--)
            {
                d++;
                result += giaban[i];
                if (d == 3 && i != 0)
                {
                    result += ',';
                    d = 0;
                }
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void LblGiaGoc_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            Label p = (Label)sender;
            ucSanPham u = (ucSanPham)p.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    hd = true;
                    txtSDT.Enabled = false;
                }
            }
        }
        private void LblGiaKM_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            Label p = (Label)sender;
            ucSanPham u = (ucSanPham)p.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    hd = true;
                    txtSDT.Enabled = false;
                }
            }
        }
        private void LblKM_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            Label p = (Label)sender;
            Panel pn = (Panel)p.Parent;
            ucSanPham u = (ucSanPham)pn.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    hd = true;
                    txtSDT.Enabled = false;
                }
            }
        }
        private void LblTenSP_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            Label p = (Label)sender;
            ucSanPham u = (ucSanPham)p.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    hd = true;
                    txtSDT.Enabled = false;
                }
            }
        }
        private void Panel1_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            Panel pn = (Panel)sender;
            ucSanPham u = (ucSanPham)pn.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    txtSDT.Enabled = false;
                    hd = true;
                }
            }
        }
        private void PicSP_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            PictureBox p = (PictureBox)sender;
            ucSanPham u = (ucSanPham)p.Parent;
            u.Select();
            if (u.spDTO.SoLuong > 0)
            {
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvCTHD.Rows[i];
                    if (int.Parse(r.Cells[0].Value.ToString()) == u.spDTO.MaSP)
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        dgvCTHD.Rows[i].Selected = true;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        if (hd == true)
                        {

                        }
                        else
                        {
                            ThemHoaDon();
                            hd = true;
                            txtSDT.Enabled = false;
                        }
                        return;
                    }
                }
                tong = u.spDTO.GiaBan - ((u.spDTO.GiaBan * u.spDTO.KhuyenMai) / 100);
                dgvCTHD.Rows.Insert(dgvCTHD.Rows.Count, u.spDTO.MaSP, u.spDTO.TenSP, u.spDTO.GiaBan, u.spDTO.KhuyenMai, 1, tong, "-", "+");
                dgvCTHD.Rows[dgvCTHD.Rows.Count - 1].Selected = true;
                LoadTongHoaDon();
                if (hd == true)
                {

                }
                else
                {
                    ThemHoaDon();
                    hd = true;
                    txtSDT.Enabled = false;
                }
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPhamTheoBoLoc(1);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = "";
            cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1;
            cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1;
        }

        public object NSXDL { get; private set; }
        string tenkh = "";


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (btnThanhToan.BackColor == Color.Gray)
                return;
            this.Alert("Đã thanh toán đơn hàng...", frmPopupNotification.enmType.Success);
            this.Cursor = Cursors.AppStarting;
            if (txtTenKH.Text != "")
                KhachHangBL.Instance.CapNhatDoanhSoKhachHang(makh, ThanhTien);
            ThemCTDH();
            InHoaDon();
            LoadDanhSachSanPhamTheoBoLoc(1);
            hd = false;
            txtSDT.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void InHoaDon()
        {
            frmInHoaDon frm = new frmInHoaDon();
            frm.Show();
            frm.TopMost = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HoaDonBL.Instance.XoaHD(SOHD);
            btnHuy.BackColor = Color.Gray;
            dgvCTHD.Rows.Clear();
            hd = false;
            SOHD = 0;
            txtSDT.Text = "";
            lblTongTien.Text = "0";
            txtTienThua.Text = "";
            txtTienKHTra.Text = "";
            btnThanhToan.BackColor = Color.Gray;
            txtSDT.Enabled = true;

            this.Alert("Đã hủy đơn hàng...", frmPopupNotification.enmType.Success);
        }

        private void txtTienKHTra_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKHTra.Text != "")
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtTienKHTra.Text, System.Globalization.NumberStyles.AllowThousands);
                txtTienKHTra.Text = String.Format(culture, "{0:N0}", value);
                txtTienKHTra.Select(txtTienKHTra.Text.Length, 0);

                try
                {
                    if (ThanhTien <= decimal.Parse(txtTienKHTra.Text))
                    {
                        txtTienThua.Text = Math.Abs((ThanhTien - decimal.Parse(txtTienKHTra.Text))) + "";
                        System.Globalization.CultureInfo c = new System.Globalization.CultureInfo("en-US");
                        decimal v = decimal.Parse(txtTienThua.Text, System.Globalization.NumberStyles.AllowThousands);
                        txtTienThua.Text = String.Format(c, "{0:N0}", v);
                        txtTienThua.Select(txtTienThua.Text.Length, 0);
                        btnThanhToan.BackColor = Color.Green;
                    }
                    else
                    {
                        txtTienThua.Text = "Không đủ";
                        btnThanhToan.BackColor = Color.Gray;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            string pre = "";
            string next = "";
            string str = lblPageNumber.Text;
            bool b = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '/' && b == false)
                {
                    pre += str[i];
                    continue;
                }
                if (str[i] != '/' && b == true)
                {
                    next += str[i];
                    continue;
                }
                if (str[i] == '/')
                {
                    b = true;
                }
            }
            if (pre == next)
                return;

            string n = "";
            string num = lblPageNumber.Text;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/')
                {
                    break;
                }
                else
                {
                    n += num[i];
                }
            }
            LoadDanhSachSanPhamTheoBoLoc(int.Parse(n) + 1);
            lblPageNumber.Text = int.Parse(n) + 1 + "/" + sumpage;
            Cursor = Cursors.Default;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            string pre = "";
            string str = lblPageNumber.Text;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/')
                {
                    break;
                }
                else
                {
                    pre += str[i];
                }
            }
            if (pre == "1")
                return;

            string n = "";
            string num = lblPageNumber.Text;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/')
                {
                    break;
                }
                else
                {
                    n += num[i];
                }
            }
            LoadDanhSachSanPhamTheoBoLoc(int.Parse(n) - 1);
            lblPageNumber.Text = int.Parse(n) - 1 + "/" + sumpage;
            Cursor = Cursors.Default;
        }

        private void txtTienKHTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void btnThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void ucBanSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void dgvCTHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void btnPre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void btnNext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void txtTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void btnApDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void btnLamMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void cboLocLoaiSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void cboLocNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                ThanhToanF9();
            if (e.KeyCode == Keys.F12)
                HuyF12();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                this.Alert("HD: " + txtTenKH.Text + "...", frmPopupNotification.enmType.Info);
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DataGridViewRow r = dgvCTHD.SelectedRows[0];
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    if (r.Cells[0].Value.ToString() == dgvCTHD.Rows[i].Cells[0].Value.ToString())
                    {
                        if (int.Parse(r.Cells[4].Value.ToString()) == 1)
                        {
                            dgvCTHD.Rows.Remove(r);
                            LoadTongHoaDon();
                            return;
                        }
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) - 1;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        decimal tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();

                        if (txtTienKHTra.Text != "")
                        {
                            if (ThanhTien < decimal.Parse(txtTienKHTra.Text))
                                txtTienThua.Text = Convert((Math.Abs(ThanhTien - decimal.Parse(txtTienKHTra.Text)))) + "";
                            else
                            {
                                txtTienThua.Text = "Không đủ";
                                btnThanhToan.BackColor = Color.Gray;
                            }
                        }

                        return;
                    }
                }
            }
            if (e.ColumnIndex == 7)
            {
                DataGridViewRow r = dgvCTHD.SelectedRows[0];
                for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                {
                    if (r.Cells[0].Value.ToString() == dgvCTHD.Rows[i].Cells[0].Value.ToString())
                    {
                        dgvCTHD.Rows[i].Cells[4].Value = int.Parse(r.Cells[4].Value.ToString()) + 1;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int km = int.Parse(r.Cells[3].Value.ToString());
                        decimal giakm = giagoc - ((giagoc * km) / 100);
                        decimal tong = giakm * decimal.Parse(r.Cells[4].Value.ToString());
                        dgvCTHD.Rows[i].Cells[5].Value = tong;
                        LoadTongHoaDon();
                        try
                        {
                            if (ThanhTien <= decimal.Parse(txtTienKHTra.Text))
                            {
                                txtTienThua.Text = Convert((Math.Abs(ThanhTien - decimal.Parse(txtTienKHTra.Text)))) + "";

                            }
                            else
                            {
                                txtTienThua.Text = "Không đủ";
                                btnThanhToan.BackColor = Color.Gray;
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }

                        return;
                    }
                }
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtTenKH.ForeColor = Color.Black;
            txtTenKH.Text = KhachHangBL.Instance.GetTenKhachHang(txtSDT.Text);
            if (txtTenKH.Text == "")
            {
                picThanhCong.Visible = false;
            }
            else
            {
                tenkh = KhachHangBL.Instance.GetTenMaKH(txtSDT.Text);
                makh = int.Parse(KhachHangBL.Instance.GetTenMaKH(txtSDT.Text));
                picThanhCong.Visible = true;
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text == "Nhập vào Số Điện Thoại")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }    
        }
    }
}
