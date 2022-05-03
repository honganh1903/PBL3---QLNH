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

namespace GUI.UserControls
{
    public partial class ucNhapSanPham : UserControl
    {
        public ucNhapSanPham()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucNhapSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = SanPhamBL.Instance.GetDanhSachSanPham();
            dgvSanPham.ClearSelection();
            dgvPhieuNhap.DataSource = PhieuNhapBL.Instance.GetDanhSachPhieuNhap();
            dgvPhieuNhap.ClearSelection();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            frmChonNCC frm = new frmChonNCC();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                PhieuNhapDTO pnDTO = new PhieuNhapDTO();
                pnDTO.MaNV = frmDangNhap.TenDangNhap;
                pnDTO.MaNCC = frm.MANCC;
                mancc = pnDTO.MaNCC;
                pnDTO.NgayLap = DateTime.Now;
                dgvSanPham.DataSource = SanPhamBL.Instance.GetDanhSachSanPhamTheoNCC(mancc);
                if (dgvSanPham.Rows.Count > 0)
                {
                    if (PhieuNhapBL.Instance.ThemPhieuNhap(pnDTO))
                    {
                        mapn = PhieuNhapBL.Instance.GetMAPNMax();
                        frmThongBao frmtt = new frmThongBao();
                        this.Alert("Tạo phiếu nhập thành công...", frmPopupNotification.enmType.Success);

                        btnThem.Enabled = true;
                        btnThem.BackColor = Color.FromArgb(17, 145, 249);

                        lblDaTaoPhieuNhap.Visible = true;
                        btnTaoPhieu.Enabled = false;
                        btnTaoPhieu.BackColor = Color.Gray;
                    }
                }
                else
                {
                    frmThongBao frmtt = new frmThongBao();
                    frmtt.lblThongBao.Text = "Hiện tại chưa có sản phẩm nào từ nhà cung cấp này trong hệ thống!";
                    frmtt.ShowDialog();
                }
            }
        }
        int mapn = 0;
        int mancc = 0;
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        int maphieu = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtDonGiaNhap.Text == "")
                k = 1;
            if (txtMaSP.Text == "")
                k = 1;
            if (txtSoLuong.Text == "")
                k = 1;
            if (txtTenSP.Text == "")
                k = 1;
            if (k == 1)
            {
                frmThongBao frmtt = new frmThongBao();
                frmtt.lblThongBao.Text = "Bạn chưa nhập đủ thông tin phiếu nhập!";
                frmtt.Show();
                return;
            }
            dgvCTPN.Rows.Insert(dgvCTPN.Rows.Count, txtMaSP.Text, mapn.ToString(), frmDangNhap.TenDangNhap, SanPhamBL.Instance.GetTenSP(int.Parse(txtMaSP.Text)), txtDonGiaNhap.Text, txtSoLuong.Text);
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(17, 145, 249);
            btnHuy.Enabled = true;
            btnHuy.BackColor = Color.OrangeRed;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (PhieuNhapBL.Instance.XoaPN(mapn))
            {
                dgvCTPN.Rows.Clear();
                mapn = 0;
                frmThongBao frmtt = new frmThongBao();
                this.Alert("Đã hủy phiếu nhập...", frmPopupNotification.enmType.Info);
                btnLuu.Enabled = false;
                btnLuu.BackColor = Color.Gray;
                btnHuy.Enabled = false;
                btnHuy.BackColor = Color.Gray;
                btnThem.Enabled = false;
                btnThem.BackColor = Color.Gray;
                lblDaTaoPhieuNhap.Visible = false;
                btnTaoPhieu.Enabled = true;
                btnTaoPhieu.BackColor = Color.FromArgb(17, 145, 249);
            }
        }


        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvPhieuNhap.SelectedRows[0];
                maphieu = int.Parse(dr.Cells["Mã Phiếu"].Value.ToString().Trim());
                btnXacNhan.BackColor = Color.FromArgb(17, 145, 249);
                btnXacNhan.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(17, 145, 249);
                btnXoa.Enabled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (btnXacNhan.BackColor == Color.FromArgb(17, 145, 249) && maphieu != 0)
            {
                if (PhieuNhapBL.Instance.XacNhan(maphieu))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                if (PhieuNhapBL.Instance.CapNhatSoLuong(maphieu))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            if (result == true)
            {
                this.Alert("Đã xác nhận hàng đã về kho...", frmPopupNotification.enmType.Success);
                dgvPhieuNhap.DataSource = PhieuNhapBL.Instance.GetDanhSachPhieuNhap();
                dgvPhieuNhap.ClearSelection();
                dgvSanPham.DataSource = SanPhamBL.Instance.GetDanhSachSanPham();
                dgvSanPham.ClearSelection();
                btnXacNhan.Enabled = false;
                btnXacNhan.BackColor = Color.Gray;
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.BackColor == Color.FromArgb(17, 145, 249) && maphieu != 0)
            {
                if (PhieuNhapBL.Instance.XoaPN(maphieu))
                {
                    this.Alert("Đã xóa phiếu nhập...", frmPopupNotification.enmType.Info);
                    dgvPhieuNhap.DataSource = PhieuNhapBL.Instance.GetDanhSachPhieuNhap();
                    dgvPhieuNhap.ClearSelection();
                    btnXacNhan.Enabled = false;
                    btnXacNhan.BackColor = Color.Gray;
                    btnXoa.Enabled = false;
                    btnXoa.BackColor = Color.Gray;
                }
            }
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvCTPN.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvCTPN.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            if (CTPNBL.Instance.ThemCTPN(dt, mapn))
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtSoLuong.Clear();
                txtDonGiaNhap.Clear();
                dgvCTPN.Rows.Clear();

                mapn = 0;
                frmThongBao frmtt = new frmThongBao();
                this.Alert("Lưu phiếu nhập thành công...", frmPopupNotification.enmType.Success);

                dgvPhieuNhap.DataSource = PhieuNhapBL.Instance.GetDanhSachPhieuNhap();
                dgvPhieuNhap.ClearSelection();

                btnLuu.Enabled = false;
                btnLuu.BackColor = Color.Gray;
                btnHuy.Enabled = false;
                btnHuy.BackColor = Color.Gray;
                btnThem.Enabled = false;
                btnThem.BackColor = Color.Gray;
                lblDaTaoPhieuNhap.Visible = false;
                btnTaoPhieu.Enabled = true;
                btnTaoPhieu.BackColor = Color.FromArgb(17, 145, 249);
            }
        }
    }
}
