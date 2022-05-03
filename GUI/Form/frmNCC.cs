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

namespace GUI
{
    public partial class frmNCC : Form
    {
        public frmNCC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool b = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtSDT.Text == "")
            {
                txtSDT.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (k == 1)
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin nhà cung cấp";
                frm.ShowDialog();
                return;
            }
            if (txtTen.Text.Length < 50)
            {
                if (txtDiaChi.Text.Length <= 200)
                {
                    if (txtSDT.Text.Length <= 12 && txtSDT.Text.Length >= 10)
                    {
                        NhaCungCapDTO nccDTO = new NhaCungCapDTO();
                        nccDTO.TenNCC = txtTen.Text;
                        nccDTO.Email = txtEmail.Text;
                        nccDTO.DiaChi = txtDiaChi.Text;
                        nccDTO.SDT = txtSDT.Text;
                        if (NCCBL.Instance.ThemNCCFull(nccDTO))
                        {
                            this.Alert("Thêm thành công...", frmPopupNotification.enmType.Success);
                            LoadDataGridView();
                            txtDiaChi.Text = "";
                            txtSDT.Text = "";
                            txtTen.Text = "";
                            txtEmail.Text = "";
                            b = true;
                        }
                    }
                    else
                    {
                        frmThongBao frm = new frmThongBao();
                        frm.lblThongBao.Text = "Số điện thoại phải từ 10 đến 12 số!";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Địa chỉ tối đa 200 ký tự!";
                    frm.ShowDialog();
                }
            }
            else
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Tên NCC chỉ được tối đa 50 ký tự!";
                frm.ShowDialog();
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void LoadDataGridView()
        {
            dgvNCC.DataSource = NCCBL.Instance.GetDanhSachNCC();
        }
        int mancc = 0;

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtSDT.Text == "")
            {
                txtSDT.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (k == 1)
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin nhà cung cấp";
                frm.ShowDialog();
                return;
            }
            if (txtTen.Text.Length < 50)
            {
                if (txtDiaChi.Text.Length <= 200)
                {
                    if (txtSDT.Text.Length <= 12 && txtSDT.Text.Length >= 10)
                    {
                        NhaCungCapDTO nccDTO = new NhaCungCapDTO();
                        nccDTO.MaNCC = mancc;
                        nccDTO.TenNCC = txtTen.Text;
                        nccDTO.Email = txtEmail.Text;
                        nccDTO.DiaChi = txtDiaChi.Text;
                        nccDTO.SDT = txtSDT.Text;
                        if (NCCBL.Instance.CapNhatNCC(nccDTO))
                        {
                            this.Alert("Đã cập nhật thành công...", frmPopupNotification.enmType.Success);
                            LoadDataGridView();
                            txtDiaChi.Text = "";
                            txtSDT.Text = "";
                            txtTen.Text = "";
                            txtEmail.Text = "";
                            b = true;
                        }
                    }
                    else
                    {
                        frmThongBao frm = new frmThongBao();
                        frm.lblThongBao.Text = "Số điện thoại phải từ 10 đến 12 số!";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Địa chỉ tối đa 200 ký tự!";
                    frm.ShowDialog();
                }
            }
            else
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Tên NCC chỉ được tối đa 50 ký tự!";
                frm.ShowDialog();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (NCCBL.Instance.XoaNCC(mancc.ToString()))
            {
                this.Alert("Đã ngừng hợp tác thành công...", frmPopupNotification.enmType.Success);
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtTen.Text = "";
                txtEmail.Text = "";
                LoadDataGridView();
                b = true;
            }
        }

        private void dgvNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNCC.SelectedRows.Count == 1)
                {
                    if (txtTen.BackColor == Color.OrangeRed)
                    {
                        txtTen.BackColor = Color.FromArgb(51, 51, 51);
                    }
                    if (txtDiaChi.BackColor == Color.OrangeRed)
                    {
                        txtDiaChi.BackColor = Color.FromArgb(51, 51, 51);
                    }
                    if (txtEmail.BackColor == Color.OrangeRed)
                    {
                        txtEmail.BackColor = Color.FromArgb(51, 51, 51);
                    }
                    if (txtSDT.BackColor == Color.OrangeRed)
                    {
                        txtSDT.BackColor = Color.FromArgb(51, 51, 51);
                    }
                    DataGridViewRow dr = dgvNCC.SelectedRows[0];
                    mancc = int.Parse(dr.Cells["Mã NCC"].Value.ToString().Trim());
                    txtTen.Text = dr.Cells["Tên NCC"].Value.ToString().Trim();
                    txtDiaChi.Text = dr.Cells["Địa Chỉ NCC"].Value.ToString().Trim();
                    txtSDT.Text = dr.Cells["SĐT"].Value.ToString().Trim();
                    txtEmail.Text = dr.Cells["Email"].Value.ToString().Trim();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
