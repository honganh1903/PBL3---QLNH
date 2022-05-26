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
    public partial class frmNL : Form
    {
        public frmNL()
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
                txtTen.BackColor = Color.Red;
                k = 1;
            }
            else txtTen.BackColor = Color.White;
            if (txtDVT.Text == "")
            {
                txtDVT.BackColor = Color.Red;
                k = 1;
            }
            else txtDVT.BackColor = Color.White;
            if (txtDGN.Text == "" || IsNumber(txtDGN.Text)==false)
            {
                txtDGN.BackColor = Color.Red;
                k = 1;
            }
            else txtDGN.BackColor = Color.White;
            if (txtSL.Text == "" || IsNumber(txtSL.Text) == false) 
            {
                txtSL.BackColor = Color.Red;
                k = 1;
            }
            else txtSL.BackColor = Color.White;
            if (k == 1)
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin Nguyên Liệu";
                frm.ShowDialog();
                return;
            }
            if (txtTen.Text.Length <= 50)
            {
                if (txtDVT.Text.Length <= 20)
                {
                        NguyenLieuDTO nlDTO = new NguyenLieuDTO();
                        nlDTO.TenNL = txtTen.Text;
                        nlDTO.DVT = txtDVT.Text;
                        nlDTO.DonGiaNhap = Convert.ToDecimal(txtDGN.Text);
                        nlDTO.MaNCC = getMaNCC();
                        nlDTO.SoLuong = Convert.ToInt32(txtSL.Text);
                        if (NguyenLieuBL.Instance.ThemNL(nlDTO))
                        {
                            this.Alert("Thêm thành công...", frmPopupNotification.enmType.Success);
                            LoadDataGridView();
                            b = true;
                        }
                    }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Đơn vị tính tối đa 20 ký tự!";
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
            DataTable dt = NguyenLieuBL.Instance.GetDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = dt;
        }

        private void setCBB()
        {
            DataTable dt = NCCBL.Instance.GetDanhSachNCCFull();
            foreach(DataRow i in dt.Rows)
            {
                cbbNCC.Items.Add(i["Mã NCC"]+" - "+i["Tên NCC"].ToString());
            }
            cbbNCC.Text = cbbNCC.Items[0].ToString();
        }
        private int getMaNCC()
        {
            string s = "";
            foreach(char i in cbbNCC.Text.ToCharArray())
            {
                if (i == ' ') break;
                s += i;
            }
            return Convert.ToInt32(s);
        }
        private int getMaNCC(string x)
        {
            string s = "";
            foreach (char i in x.ToCharArray())
            {
                if (i == ' ') break;
                s += i;
            }
            return Convert.ToInt32(s);
        }

        private void frmNL_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            setCBB();
        }
        int manl = 0;
        private void dgvNguyenLieu_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (dgvNguyenLieu.SelectedRows.Count == 1)
                {
                    if (txtTen.BackColor == Color.Red)
                    {
                        txtTen.BackColor = Color.White;
                    }
                    if (txtDGN.BackColor == Color.Red)
                    {
                        txtDGN.BackColor = Color.White;
                    }
                    if (txtDVT.BackColor == Color.Red)
                    {
                        txtDVT.BackColor = Color.White;
                    }
                    if (txtSL.BackColor == Color.Red)
                    {
                        txtSL.BackColor = Color.White;
                    }
                    DataGridViewRow dr = dgvNguyenLieu.SelectedRows[0];
                    manl = int.Parse(dr.Cells["Mã NL"].Value.ToString().Trim());
                    txtTen.Text = dr.Cells["Tên NL"].Value.ToString().Trim();
                    txtDVT.Text = dr.Cells["ĐVT"].Value.ToString().Trim();
                    txtDGN.Text = dr.Cells["Đơn Giá Nhập"].Value.ToString().Trim();
                    txtSL.Text = dr.Cells["Số Lượng"].Value.ToString().Trim();
                    for(i=0;i<cbbNCC.Items.Count;i++)
                    {
                        if (getMaNCC(cbbNCC.Items[i].ToString())==Convert.ToInt16(dr.Cells["Mã NCC"].Value.ToString()))
                        {
                            cbbNCC.Text = cbbNCC.Items[i].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.Red;
                k = 1;
            }
            if (txtDVT.Text == "")
            {
                txtDVT.BackColor = Color.Red;
                k = 1;
            }
            if (txtDGN.Text == "")
            {
                txtDGN.BackColor = Color.Red;
                k = 1;
            }
            if (txtSL.Text == "")
            {
                txtSL.BackColor = Color.Red;
                k = 1;
            }
            if (k == 1)
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin Nguyên Liệu";
                frm.ShowDialog();
                return;
            }
            if (txtTen.Text.Length <= 50)
            {
                if (txtDVT.Text.Length <= 20)
                {
                    NguyenLieuDTO nlDTO = new NguyenLieuDTO();
                    nlDTO.MaNL = manl;
                    nlDTO.TenNL = txtTen.Text;
                    nlDTO.DVT = txtDVT.Text;
                    nlDTO.DonGiaNhap = Convert.ToDecimal(txtDGN.Text);
                    nlDTO.MaNCC = getMaNCC();
                    nlDTO.SoLuong = Convert.ToInt32(txtSL.Text);
                    if (NguyenLieuBL.Instance.CapNhatNL(nlDTO))
                    {
                        this.Alert("Cập nhật thành công...", frmPopupNotification.enmType.Success);
                        LoadDataGridView();
                        b = true;
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Đơn vị tính tối đa 20 ký tự!";
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

            try
            {
                if (dgvNguyenLieu.SelectedRows.Count ==0)
                {
                    MessageBox.Show("Vui lòng chọn nguyên liệu!");
                }
                else
                {
                    for (int i = 0; i < dgvNguyenLieu.SelectedRows.Count; i++)
                    {
                        manl =Convert.ToInt16(dgvNguyenLieu.SelectedRows[i].Cells["Mã NL"].Value.ToString());
                        NguyenLieuBL.Instance.XoaNL(manl);
                    }
                    this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                    LoadDataGridView();
                }
            }catch(Exception ex) { return; }
        }
        private bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
