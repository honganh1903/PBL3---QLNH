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
         int masp=0;
        public frmThemTP(int MA)
        {
            masp = MA;
            InitializeComponent();
        }

        private void frmThemTP_Load(object sender, EventArgs e)
        {
            dgvNguyenLieu.DataSource = NguyenLieuBL.Instance.GetDanhSachNguyenLieu();
            dgvNguyenLieu.ClearSelection();
            dgvSanPham.DataSource = CTSPBL.Instance.GetDanhSachNguyenLieu(masp);
            dgvSanPham.ClearSelection();
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


        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvSanPham.SelectedRows[0];
                btnXacNhan.BackColor = Color.FromArgb(17, 145, 249);
                btnXacNhan.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(17, 145, 249);
                btnXoa.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
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
                frmtt.lblThongBao.Text = "Bạn chưa nhập đủ thông tin phiếu nhập!";
                frmtt.Show();
                return;
            }
            if (CTSPBL.Instance.ThemThanhPhan(masp, int.Parse(txtMaNL.Text), int.Parse(txtSoLuong.Text))){
                dgvSanPham.DataSource = CTSPBL.Instance.GetDanhSachNguyenLieu(masp);
                dgvSanPham.ClearSelection();
                txtDVT.Clear();
                txtTenNL.Clear();
                txtSoLuong.Clear();
                txtDonGiaNhap.Clear();
                btnXacNhan.Enabled = true;
                btnXacNhan.BackColor = Color.FromArgb(17, 145, 249);
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.OrangeRed;

            }
        }
    }
}
