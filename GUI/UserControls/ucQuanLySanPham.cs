using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using GUI;
using System.IO;

namespace GUI.UserControls
{
    public partial class ucQuanLySanPham : UserControl
    {
        public ucQuanLySanPham()
        {
            InitializeComponent();
        }

        private void dateNgaySX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pnlNCC_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            frm.ShowDialog();
            if (frm.b)
            {
                LoadCboNCC();
                LoadCboLocNCC();
            }
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

        private void LoadCboNCC()
        {
            //cboNCC.DataSource = NCCBL.Instance.GetDanhSachNCC();
            //cboNCC.DisplayMember = "Tên NCC";
            //cboNCC.ValueMember = "Mã NCC";
        }

        private void ucQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadCboLoaiSP();
            LoadCboDVT();
            LoadCboNCC();
            LoadCboLocLoaiSP();
            LoadCboLocNCC();
            LoadDataGridViewTheoBoLoc();
        }

        private void LoadDataGridViewTheoBoLoc()
        {
            dgvSanPham.DataSource = SanPhamBL.Instance.GetDanhSachSanPhamTheoBoLoc(txtTenSP.Text.Trim(), cboLocLoaiSP.SelectedValue.ToString().Trim(), cboLocNCC.SelectedValue.ToString().Trim());
            dgvSanPham.ClearSelection();
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


        private void LoadCboDVT()
        {
            //cboDVT.DataSource = SanPhamBL.Instance.GetDanhSachDVT();
            //cboDVT.ValueMember = "Đơn Vị Tính";
            //cboLoai.DisplayMember = "Mã SP";
            cboDVT.SelectedIndex = 0;
        }

        private void LoadCboLoaiSP()
        {
            cboLoai.DataSource = LoaiSanPhamBL.Instance.GetDanhSachLoaiSanPham();
            cboLoai.DisplayMember = "Tên Loại SP";
            cboLoai.ValueMember = "Mã Loại SP";
        }

        private void LoadDataGridView()
        {
            DataTable dt = SanPhamBL.Instance.GetDanhSachSanPham();
            dgvSanPham.DataSource = dt;
        }

        private void pnlLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham();
            frm.ShowDialog();
            if (frm.b)
            {
                LoadCboLoaiSP();
                LoadCboLocLoaiSP();
                LoadDataGridViewTheoBoLoc();
            }
        }
        int masp = 0;

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.SelectedRows.Count == 1)
                {
                    ResetColorControls();
                    DataGridViewRow dr = dgvSanPham.SelectedRows[0];
                    masp = int.Parse(dr.Cells["Mã SP"].Value.ToString().Trim());
                    txtTen.Text = dr.Cells["Tên SP"].Value.ToString().Trim();
                    cboLoai.SelectedValue = dr.Cells["Mã Loại SP"].Value.ToString();
                    cboDVT.SelectedItem = dr.Cells["ĐVT"].Value.ToString();
                    txtGiaNhap.Text = dr.Cells["Đơn Giá Nhập"].Value.ToString().Trim();
                    txtLoiNhuan.Text = dr.Cells["Lợi Nhuận"].Value.ToString().Trim();
                    txtGiaBan.Text = dr.Cells["Đơn Giá Bán"].Value.ToString().Trim();
                    txtSoLuong.Text = dr.Cells["Số Lượng"].Value.ToString().Trim();
                    txtKhuyenMai.Text = dr.Cells["Khuyến Mãi"].Value.ToString().Trim();
                    MemoryStream ms = new MemoryStream((byte[])dgvSanPham.CurrentRow.Cells["Hình Ảnh"].Value‌​);
                    picHinhAnh.Image = Image.FromStream(ms);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void ResetColorControls()
        {
            foreach (Control ctrl in pnThongTinSanPham.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.BackColor == Color.OrangeRed)
                    {
                        ctrl.BackColor = Color.White;
                    }
                }
            }
            if (picHinhAnh.BackColor == Color.OrangeRed)
            {
                picHinhAnh.BackColor = Color.White;
            }
        }
        private void LamMoi()
        {
            txtTen.Clear();
            txtSoLuong.Clear();
            txtKhuyenMai.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtLoiNhuan.Clear();
            cboDVT.SelectedIndex = 0;
            if (cboLoai.Items.Count > 0)
                cboLoai.SelectedIndex = 0;
            picHinhAnh.Image = null;
            ResetColorControls();
        }

        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            frmThemLoaiSP frm = new frmThemLoaiSP();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCboLoaiSP();
                cboLoai.SelectedIndex = cboLoai.Items.Count - 1;
                LoadCboLocLoaiSP();
            }
        }

        private void btnLamMoiThongTin_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            if (CheckControls())
            {
                if (SanPhamBL.Instance.NgungKinhDoanhSanPham(masp.ToString()))
                {
                    LamMoi();
                    LoadDataGridViewTheoBoLoc();
                    this.Alert("Đã ngừng kinh doanh...", frmPopupNotification.enmType.Success);
                }
            }
            else
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa chọn sản phẩm cần ngừng kinh doanh!";
                frm.ShowDialog();
            }
        }
        int i = 0;
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        private bool CheckControls()
        {
            int r = 0;
            foreach (Control ctrl in pnThongTinSanPham.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.Text == "" && ctrl.Name != "txtSoLuong" && ctrl.Name != "txtGiaBan")
                    {
                        ctrl.BackColor = Color.OrangeRed;
                        r = 1;
                    }
                }
            }
            if (picHinhAnh.Image == null)
            {
                r = 1;
                picHinhAnh.BackColor = Color.OrangeRed;
            }
            if (r == 0)
                return true;
            return false;
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if (picHinhAnh.BackColor == Color.OrangeRed)
            {
                picHinhAnh.BackColor = Color.White;
            }
            frmLoadImage frm = new frmLoadImage();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = frm.img;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (CheckControls())
            {
                if (txtTen.Text.Length < 200)
                {
                    if (int.Parse(txtKhuyenMai.Text) < 100)
                    {
                        if (int.Parse(txtLoiNhuan.Text) > 0)
                        {

                                SanPhamDTO spDTO = new SanPhamDTO();
                                spDTO.TenSP = txtTen.Text;
                                spDTO.MaLoaiSP = cboLoai.SelectedValue.ToString().Trim();
                                spDTO.DVT = cboDVT.SelectedItem.ToString();
                                spDTO.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                                spDTO.LoiNhuan = int.Parse(txtLoiNhuan.Text);
                                spDTO.GiaBan = decimal.Parse(txtGiaBan.Text);
                                spDTO.KhuyenMai = int.Parse(txtKhuyenMai.Text);
                                Image img = picHinhAnh.Image;
                                spDTO.HinhAnh = ImageToByteArray(img);

                                cboLocLoaiSP.SelectedIndex = cboLoai.SelectedIndex;
                                if (SanPhamBL.Instance.ThemSanPham(spDTO))
                                {
                                    this.Alert("Đã thêm sản phẩm thành công...", frmPopupNotification.enmType.Success);
                                    LoadDataGridViewTheoBoLoc();
                                    LamMoi();
                                }
                        }
                        else
                        {
                            frmThongBao frm = new frmThongBao();
                            frm.lblThongBao.Text = "Lợi nhuận phải lớn hơn 0%!";
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        frmThongBao frm = new frmThongBao();
                        frm.lblThongBao.Text = "Khuyến mãi phải nhỏ hơn 100%!";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Tên sản phẩm tối đa 200 ký tự!";
                    frm.ShowDialog();
                }
            }
            else
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin sản phẩm";
                frm.ShowDialog();
            }
        }


        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            if (CheckControls())
            {
                if (txtTen.Text.Length < 200)
                {
                    if (int.Parse(txtKhuyenMai.Text) < 100)
                    {
                        if (int.Parse(txtLoiNhuan.Text) > 0)
                        {
                                SanPhamDTO spDTO = new SanPhamDTO();
                                spDTO.MaSP = masp;
                                spDTO.TenSP = txtTen.Text;
                                spDTO.LoiNhuan = int.Parse(txtLoiNhuan.Text);
                                spDTO.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                                spDTO.GiaBan = decimal.Parse(txtGiaBan.Text);
                                spDTO.KhuyenMai = int.Parse(txtKhuyenMai.Text);
                                Image img = picHinhAnh.Image;
                                spDTO.HinhAnh = ImageToByteArray(img);

                                cboLocLoaiSP.SelectedIndex = cboLoai.SelectedIndex;

                                if (SanPhamBL.Instance.SuaSanPham(spDTO))
                                {
                                    LoadDataGridViewTheoBoLoc();
                                    LamMoi();
                                    this.Alert("Cập nhật sản phẩm thảnh công...", frmPopupNotification.enmType.Success);
                                }
                                else
                                {
                                    this.Alert("Cập nhật thất bại...", frmPopupNotification.enmType.Success);
                                }
                        }
                        else
                        {
                            frmThongBao frm = new frmThongBao();
                            frm.lblThongBao.Text = "Lợi nhuận phải lớn hơn 0%!";
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        frmThongBao frm = new frmThongBao();
                        frm.lblThongBao.Text = "Khuyến mãi phải nhỏ hơn 100%!";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Tên sản phẩm tối đa 200 ký tự!";
                    frm.ShowDialog();
                }
            }
            else
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin sản phẩm";
                frm.ShowDialog();
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            LoadDataGridViewTheoBoLoc();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = "";
            cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1;
            cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1;
        }

        private void txtTen_Click(object sender, EventArgs e)
        {
            if (txtTen.BackColor == Color.OrangeRed)
            {
                txtTen.BackColor = Color.White;
            }
        }

        private void txtSoLuong_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.BackColor == Color.OrangeRed)
            {
                txtSoLuong.BackColor = Color.White;
            }
        }

        private void txtKhuyenMai_Click(object sender, EventArgs e)
        {
            if (txtKhuyenMai.BackColor == Color.OrangeRed)
            {
                txtKhuyenMai.BackColor = Color.White;
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaNhap.Text != "")
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtGiaNhap.Text, System.Globalization.NumberStyles.AllowThousands);
                txtGiaNhap.Text = String.Format(culture, "{0:N0}", value);
                txtGiaNhap.Select(txtGiaNhap.Text.Length, 0);
            }
        }

        private void txtLoiNhuan_TextChanged(object sender, EventArgs e)
        {
            if (txtLoiNhuan.Text == "")
            {
                txtGiaBan.Clear();
                return;
            }
            if (int.Parse(txtLoiNhuan.Text) > 0)
            {
                int n = int.Parse(txtGiaNhap.Text.Replace(",", "")) + ((int.Parse(txtGiaNhap.Text.Replace(",", "")) * int.Parse(txtLoiNhuan.Text.Replace(",", "")) / 100));
                txtGiaBan.Text = ConvertTien((double)n);
            }
            else
            {
                txtGiaBan.Clear();
            }
        }

        private string ConvertTien(double gia)
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

        private void btnThemTP_Click(object sender, EventArgs e)
        {
            frmThemTP frm = new frmThemTP(masp);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                
            }
        }
    }
}
