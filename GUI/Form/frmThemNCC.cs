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
    public partial class frmThemNCC : Form
    {
        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập tên nhà cung cấp!";
                frm.ShowDialog();
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO();
            nccDTO.TenNCC = txtTenNCC.Text;
            if (NCCBL.Instance.ThemNCC(nccDTO))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
