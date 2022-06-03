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
using System.IO;

namespace GUI
{
    public partial class frmThemNhanVien : Form
    {
        public delegate void mydel();
        public mydel d { get; set; }
        private string MANV { get; set; }
        public frmThemNhanVien(string MS = "")
        {
            InitializeComponent();
            MANV = MS;
            SetCBB();
            if (MANV != "")
            {
                GUI();
            }

        }

        public void SetCBB()
        {
            string query = "select *from LOAINHANVIEN";
            foreach (DataRow i in LoaiNhanVienBL.Instance.SetCBB(query).Rows)
            {
                cbchucvu.Items.Add(
                    new LoaiNhanVienDTO
                    {
                        Value = Convert.ToInt32(i["MALOAI"].ToString()),
                        Text = i["TENLOAI"].ToString()
                    });
            }
        }
        private void GUI()
        {
            string query = "select * from NHANVIEN where MANV='" + MANV + "'";
            txtmanv.Enabled = false;
            txtmanv.Text = LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["MANV"].ToString();
            txthovaten.Text = LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["HOTEN"].ToString();
            txtsdt.Text = LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["SDT"].ToString();
            txtemail.Text = LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["EMAIL"].ToString();
            dateTimePicker1.Value = (DateTime)LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["NGAYSINH"];
            if (Convert.ToBoolean(LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["GioiTinh"]) == true)
                rdnam.Checked = true;
            else
                rdnu.Checked = true;
            try
            {
                MemoryStream memoryStream = new MemoryStream((byte[])LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["HINHANH"]);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
            }

            int MALOAI = Convert.ToInt32(LoaiNhanVienBL.Instance.SetCBB(query).Rows[0]["MALOAI"]);
            foreach (LoaiNhanVienDTO i in cbchucvu.Items)
            {
                if (i.Value == MALOAI)
                {
                    cbchucvu.SelectedItem = i;
                    break;
                }
            }
        }
        public NhanVienDTO NhanVien()
        {

            NhanVienDTO nvDTO = new NhanVienDTO();
            if (MANV != "")
            {
                nvDTO.MaNV = Convert.ToInt32(txtmanv.Text);
            }
            nvDTO.TenNV = txthovaten.Text;
            nvDTO.SDT = txtsdt.Text;
            nvDTO.Email = txtemail.Text;
            nvDTO.NgaySinh = dateTimePicker1.Value;
            if (rdnam.Checked) nvDTO.GioiTinh = true; else nvDTO.GioiTinh = false;
            nvDTO.HinhAnh = ImageToBy(pictureBox1);
            nvDTO.MaLoaiNV = cbchucvu.SelectedIndex + 1;
            return nvDTO;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Ảnh";
            openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }
        private byte[] ImageToBy(PictureBox pictureBox1)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (MANV != "")
                {
                    NhanVienBL.Instance.upnhanvien(NhanVien());
                    d();
                    this.Alert("Sửa Thành Công...", frmPopupNotification.enmType.Success);
                    this.Close();

                }
                else
                {
                    NhanVienBL.Instance.ThemNhanVien(NhanVien());
                    d();
                    this.Alert("Thêm Thành Công...", frmPopupNotification.enmType.Success);
                    this.Close();
                }
            }
            else
            {
                this.Alert("Thiếu Dữ Liệu...", frmPopupNotification.enmType.Success);
            }
        }
        public bool KiemTra()
        {
            int i = 0;
            if (string.IsNullOrWhiteSpace(txthovaten.Text))
            {
                txthovaten.BackColor = Color.Red;
                i++;
            }
            else
            {
                txthovaten.BackColor = Color.White;
            }
            ;
            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                txtsdt.BackColor = Color.Red;
                i++;
            }
            else
            {
                txtsdt.BackColor = Color.White;
            };
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                txtemail.BackColor = Color.Red;
                i++;
            }
            else
            {
                txtemail.BackColor = Color.White;
            };
            if (rdnam.Checked == false && rdnu.Checked == false)
            {
                rdnam.BackColor = Color.Red;
                rdnu.BackColor = Color.Red;
                i++;
            }
            else
            {
                {
                    rdnam.BackColor = Color.White;
                    rdnu.BackColor = Color.White;

                }
            };
            if (pictureBox1.Image == null)
            {
                pictureBox1.BackColor = Color.Red;
                i++;
            }
            else
            {
                pictureBox1.BackColor = Color.Red;
            }; ;
            if (string.IsNullOrWhiteSpace(cbchucvu.Text))
            {
                cbchucvu.BackColor = Color.Red;
                i++;
            }
            else
            {
                cbchucvu.BackColor = Color.Red;
            };
            if (i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

    }
}
