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
    public partial class ucKhachHang : UserControl
    {
        public int checkselect = 0;
        public int makh = 0;
        public int maDS = -1;// -1 : All, 0 : hien tai, 1 : da xoa
        public ucKhachHang()
        {
            InitializeComponent();
            SetCBBSearch();
        }
        private void SetCBBSearch()
        {
            cbbSearch.Items.AddRange(new string[]
            {
                "Tên khách hàng",
                "Địa chỉ",
                "Số điên thoại",
                "Email"
            });
            cbbSearch.SelectedItem = cbbSearch.Items[0];
        }
        private void load()
        {
            maDS = -1;
            dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachAllKhachHang();
            lbDSNow.Text = "Danh sách toàn bộ khách hàng";
            dgvKhachHang.Columns["Mã khách hàng"].Visible = false;
            dgvKhachHang.Columns["Đã xóa"].Visible = false;
            LockInfomationKH();
        }
        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }
        private void LockInfomationKH()
        {
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            rbNam.Enabled = false;
            rbNu.Enabled = false;
            txtEmail.ReadOnly = true;
            txtDoanhSo.ReadOnly = true;
            btSAVE.Enabled = false;
            dtpNgayDangKy.Enabled = false;
            cboxTinhTrang.Enabled = false;
        }
        private void UnLockInfomationKH()
        {
            txtTenKH.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            rbNam.Enabled = true;
            rbNu.Enabled = true;
            txtEmail.ReadOnly = false;
            btSAVE.Enabled = true;
            dtpNgayDangKy.Enabled = true;
            cboxTinhTrang.Enabled = true;
        }

        private void btSAVE_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (rbNam.Checked == false && rbNu.Checked == false)
            {
                grbGioiTinh.BackColor = Color.Red;
                k = 1;
            }
            else
            {
                grbGioiTinh.BackColor = Color.White;
            }
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.BackColor = Color.Red;
                k = 1;
            }
            else
            {
                txtDiaChi.BackColor = Color.White;
            }
            if (txtTenKH.Text == "")
            {
                txtTenKH.BackColor = Color.Red;
                k = 1;
            }
            else
            {
                txtTenKH.BackColor = Color.White;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.Red;
                k = 1;
            }
            else
            {
                txtEmail.BackColor = Color.White;
            }
            if (txtSDT.Text == "")
            {
                txtSDT.BackColor = Color.Red;
                k = 1;
            }
            else
            {
                txtSDT.BackColor = Color.White;
            }
            if (k == 0)
            {
                KhachHangDTO khDTO = new KhachHangDTO();
                if (checkselect == 2) khDTO.MaKH = makh;
                khDTO.TenKH = txtTenKH.Text;
                khDTO.DiaChi = txtDiaChi.Text;
                khDTO.SDT = txtSDT.Text;
                if (rbNam.Checked == true) khDTO.GioiTinh = true;
                else if (rbNu.Checked) khDTO.GioiTinh = false;
                khDTO.NgayDangKy = dtpNgayDangKy.Value.Date;
                khDTO.Email = txtEmail.Text;
                if (checkselect == 1)
                {
                    khDTO.DoanhSo = 0;
                    KhachHangBL.Instance.ThemKhachHang(khDTO);
                    this.Alert("Thêm thành công...", frmPopupNotification.enmType.Success);
                }
                else if (checkselect == 2)
                {
                    khDTO.DaXoa = cboxTinhTrang.Checked;
                    KhachHangBL.Instance.SuaKhachHang(khDTO);
                    this.Alert("Sửa thành công...", frmPopupNotification.enmType.Success);
                }
                UnLockInfomationKH();
                LockInfomationKH();
                load();
            }
        }

        private void btNEW_Click(object sender, EventArgs e)
        {
            UnLockInfomationKH();
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
            txtEmail.Text = "";
            txtDoanhSo.Text = "";
            cboxTinhTrang.Checked = false;
            cboxTinhTrang.Enabled = false;
            checkselect = 1;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            int kiemtra = 0;
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa ");
            }
            else
            {
                int[] del = new int[dgvKhachHang.SelectedRows.Count];
                bool[] listCheck = new bool[dgvKhachHang.SelectedRows.Count];
                for (int i = 0; i < dgvKhachHang.SelectedRows.Count; i++)
                {
                    del[i] = (Convert.ToInt16(dgvKhachHang.SelectedRows[i].Cells["Mã khách hàng"].Value.ToString()));
                    listCheck[i] = ((Boolean)dgvKhachHang.SelectedRows[i].Cells["Đã xóa"].Value);
                }
                foreach (bool tmp in listCheck)
                {
                    if (tmp == true)
                    {
                        MessageBox.Show("Thông tin được chọn đã được xóa từ trước!");
                        kiemtra = 1;
                        break;
                    }
                }
                if (kiemtra == 0)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dlr == DialogResult.Yes)
                    {
                        KhachHangDTO khDTO = new KhachHangDTO();
                        for (int i = 0; i < dgvKhachHang.SelectedRows.Count; i++)
                        {
                            khDTO.MaKH = del[i];
                            khDTO.DaXoa = true;
                            KhachHangBL.Instance.XoaKhachHang(khDTO);
                        }
                        this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                        load();
                    }
                }
            }
        }

        private void btEDIT_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count != 1)
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            if (dgvKhachHang.SelectedRows.Count == 1)
            {
                UnLockInfomationKH();
                cboxTinhTrang.Enabled = true;
                checkselect = 2;
            }
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btHienTai_Click(object sender, EventArgs e)
        {
            maDS = 0;
            dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachKhachHangHT();
            lbDSNow.Text = "Danh sách khách hàng hiên tại";
        }

        private void btDaXoa_Click(object sender, EventArgs e)
        {

            maDS = 1;
            dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachKhachHangDX();
            lbDSNow.Text = "Danh sách khách hàng đã xóa";
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rbNu.Checked = true;
            lbTinhTrang.Visible = true;
            cboxTinhTrang.Visible = true;
            makh = Convert.ToInt16(dgvKhachHang.SelectedRows[0].Cells["Mã khách hàng"].Value.ToString());
            txtTenKH.Text = dgvKhachHang.SelectedRows[0].Cells["Họ tên"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.SelectedRows[0].Cells["Địa chỉ"].Value.ToString();
            txtSDT.Text = dgvKhachHang.SelectedRows[0].Cells["SĐT"].Value.ToString();
            rbNam.Checked = (Boolean)(dgvKhachHang.SelectedRows[0].Cells["Giới tính"].Value.ToString() == "Nam");
            dtpNgayDangKy.Value = (DateTime)dgvKhachHang.SelectedRows[0].Cells["Ngày đăng ký"].Value;
            txtEmail.Text = dgvKhachHang.SelectedRows[0].Cells["Email"].Value.ToString();
            txtDoanhSo.Text = dgvKhachHang.SelectedRows[0].Cells["Doanh số"].Value.ToString();
            cboxTinhTrang.Checked = (Boolean)dgvKhachHang.SelectedRows[0].Cells["Đã xóa"].Value;
        }

        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cbbSearch.SelectedIndex)
            {
                case 0:
                    {
                        dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachByName(txtSearch.Text, maDS);
                        break;
                    }
                case 1:
                    {
                        dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachByDC(txtSearch.Text, maDS);
                        break;
                    }
                case 2:
                    {
                        dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachBySDT(txtSearch.Text, maDS);
                        break;
                    }
                case 3:
                    {
                        dgvKhachHang.DataSource = KhachHangBL.Instance.GetDanhSachByMail(txtSearch.Text, maDS);
                        break;
                    }
            }
        }
    }
}
