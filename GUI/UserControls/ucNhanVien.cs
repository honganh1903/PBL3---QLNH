using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI;

namespace GUI.UserControls
{
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
            cbtimkiem.SelectedIndex = 0;
            ShowNV();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanv.Text) && string.IsNullOrWhiteSpace(txthovaten.Text) && string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getAllNhanVien();
            }
            else
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien(txtmanv.Text, txthovaten.Text, txtsdt.Text);
            }
        }
        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            if (cbtimkiem.SelectedIndex == 0)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getAllNhanVien();
            }
            if (cbtimkiem.SelectedIndex == 1)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien(txttimkiem.Text, "", "");
            }
            if (cbtimkiem.SelectedIndex == 2)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien("", txttimkiem.Text, "");
            }
            if (cbtimkiem.SelectedIndex == 3)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien("", "", txttimkiem.Text);
            }
        }

        public void ShowNV()
        {
            dgvnhanvien.DataSource = NhanVienBL.Instance.getAllNhanVien();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvnhanvien.SelectedRows.Count > 0)
            {
                List<string> MNV = new List<string>();
                foreach (DataGridViewRow row in dgvnhanvien.SelectedRows)
                {
                    MNV.Add(row.Cells[0].Value.ToString());
                }
                DialogResult re = MessageBox.Show("Ban co muon xoa khong", "", MessageBoxButtons.OKCancel);
                if (re != DialogResult.OK) return;
                NhanVienBL.Instance.deletebyMNV(MNV);
            }
            ShowNV();
        }
        private byte[] HinhAnh(PictureBox pictureBox)

        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Text = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
            txthovaten.Text = dgvnhanvien.SelectedRows[0].Cells[1].Value.ToString();
            txtsdt.Text = dgvnhanvien.SelectedRows[0].Cells[2].Value.ToString();
            if (dgvnhanvien.SelectedRows.Count == 1)
            {
                if (dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString() != "")
                {
                    string MANV = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "select * from NHANVIEN where MANV='" + MANV + "'";
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream((byte[])LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["HINHANH"]);
                        pictureBox1.Image = Image.FromStream(memoryStream);
                    }
                    catch (Exception ex)
                    {
                        pictureBox1.Image = null;
                    }
                }

                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNhanVien f = new frmThemNhanVien("");
            f.d = new frmThemNhanVien.mydel(ShowNV);
            f.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Ma = "";
            if (dgvnhanvien.SelectedRows.Count == 1)
            {

                Ma = dgvnhanvien.SelectedRows[0].Cells[0].Value.ToString();

                frmThemNhanVien f = new frmThemNhanVien(Ma);
                f.d = new frmThemNhanVien.mydel(ShowNV);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chon dong ban muon sua");
            }
        }

        private void cbtimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtimkiem.SelectedIndex == 0) txttimkiem.Enabled = false;
            else txttimkiem.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (cbtimkiem.SelectedIndex == 0)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getAllNhanVien();
            }
            if (cbtimkiem.SelectedIndex == 1)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien(txttimkiem.Text, "", "");
            }
            if (cbtimkiem.SelectedIndex == 2)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien("", txttimkiem.Text, "");
            }
            if (cbtimkiem.SelectedIndex == 3)
            {
                dgvnhanvien.DataSource = NhanVienBL.Instance.getNhanVien("", "", txttimkiem.Text);
            }
        }
    }
}
