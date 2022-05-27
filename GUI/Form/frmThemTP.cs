using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThemTP : Form
    {
        int masp = 0;
        public frmThemTP(int MA)
        {
            masp = MA;
            InitializeComponent();
        }
        public delegate void mydel(int masp);
        public mydel d;
        private void frmThemTP_Load(object sender, EventArgs e)
        {
            dgvNguyenLieu.DataSource = NguyenLieuBL.Instance.GetDanhSachNguyenLieu();
            dgvNguyenLieu.ClearSelection();
            dgvSanPham.DataSource = CTSPBL.Instance.GetDanhSachNguyenLieu(masp);
            dgvSanPham.ClearSelection();
            lbTenSP.Text = SanPhamBL.Instance.GetTenSP(masp);
        }
        int mactsp = 0;
        private void dgvNguyenLieu_Click(object sender, EventArgs e)
        {
                if (dgvNguyenLieu.SelectedRows.Count >0)
                {
                    DataGridViewRow dr = dgvNguyenLieu.SelectedRows[0];
                    txtTenNL.Text = dr.Cells["Tên NL"].Value.ToString().Trim();
                    txtDonGiaNhap.Text = dr.Cells["Đơn Giá Nhập"].Value.ToString().Trim();
                    txtDVT.Text = dr.Cells["ĐVT"].Value.ToString().Trim();
                    txtMaNL.Text = dr.Cells["Mã NL"].Value.ToString().Trim();
                }

        }

        int manl = 0;
        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvSanPham.SelectedRows[0];
                mactsp = int.Parse(dr.Cells["Mã CTSP"].Value.ToString().Trim());
                manl = int.Parse(dr.Cells["Mã NL"].Value.ToString().Trim());
                btnXoa.BackColor = Color.FromArgb(17, 145, 249);
                btnXoa.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            d(masp);
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtDonGiaNhap.Text == "")
                k = 1;
            if (txtSoLuong.Text == "")
                k = 1;
            if (txtTenNL.Text == "")
                k = 1;
            if (k == 1)
            {
                frmThongBao frmtt = new frmThongBao();
                frmtt.lblThongBao.Text = "Bạn chưa nhập đủ thông tin thành phần!";
                frmtt.Show();
                return;
            }
            if (CTSPBL.Instance.ThemThanhPhan(masp, int.Parse(txtMaNL.Text), int.Parse(txtSoLuong.Text)))
            {
                this.Alert("Đã thêm nguyên liệu...", frmPopupNotification.enmType.Success);
                dgvSanPham.DataSource = CTSPBL.Instance.GetDanhSachNguyenLieu(masp);
                dgvSanPham.ClearSelection();
                txtDVT.Clear();
                txtTenNL.Clear();
                txtSoLuong.Clear();
                txtDonGiaNhap.Clear();
                txtMaNL.Clear();
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.OrangeRed;

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.BackColor == Color.FromArgb(17, 145, 249) )
            {
                if (CTSPBL.Instance.XoaTP(mactsp,manl))
                {
                    this.Alert("Đã xóa nguyên liệu...", frmPopupNotification.enmType.Info);
                    dgvSanPham.DataSource = CTSPBL.Instance.GetDanhSachNguyenLieu(masp);
                    dgvSanPham.ClearSelection();
                    btnXoa.Enabled = false;
                    btnXoa.BackColor = Color.Gray;
                }
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
