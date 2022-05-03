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

namespace GUI
{
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvLoaiSanPham.DataSource = LoaiSanPhamBL.Instance.GetDanhSachLoaiSanPham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool b = false;
        int maloaisp = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (k == 1)
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin loại sản phẩm";
                frm.ShowDialog();
                return;
            }
            LoaiSanPhamDTO lspDTO = new LoaiSanPhamDTO();
            lspDTO.TenLoaiSP = txtTen.Text;
            if (LoaiSanPhamBL.Instance.ThemLoaiSanPham(lspDTO))
            {
                picThanhCong.Visible = true;
                timer.Start();
                LoadDataGridView();
                txtTen.Text = "";
                b = true;
            }   
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LoaiSanPhamBL.Instance.NgungKinhDoanh(maloaisp.ToString()))
            {
                picThanhCong.Visible = true;
                txtTen.Text = "";
                LoadDataGridView();
                timer.Start();
                b = true;
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_Click(object sender, EventArgs e)
        {
            if (txtTen.BackColor == Color.OrangeRed)
            {
                txtTen.BackColor = Color.FromArgb(26, 26, 26);
            }
        }
        int i = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 30)
            {
                picThanhCong.Visible = false;
                timer.Stop();
                i = 0;
            }
        }

        private void dgvLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.SelectedRows.Count == 1)
            {
                if (txtTen.BackColor == Color.OrangeRed)
                {
                    txtTen.BackColor = Color.FromArgb(51, 51, 51);
                }
                DataGridViewRow dr = dgvLoaiSanPham.SelectedRows[0];
                maloaisp = int.Parse(dr.Cells["Mã Loại SP"].Value.ToString().Trim());
                txtTen.Text = dr.Cells["Tên Loại SP"].Value.ToString().Trim();
            }
        }
    }
}
