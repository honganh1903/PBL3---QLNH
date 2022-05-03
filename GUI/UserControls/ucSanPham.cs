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

namespace GUI.UserControls
{
    public partial class ucSanPham : UserControl
    {
        public SanPhamDTO spDTO;
        public ucSanPham()
        {
            InitializeComponent();
            spDTO = new SanPhamDTO();
        }

        private void ucSanPham_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightCyan;
            timer2.Stop();
            timer1.Start();
        }

        private void ucSanPham_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            timer1.Stop();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picSP.Top > 2)
            {
                picSP.Top--;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (picSP.Top < 5)
            {
                picSP.Top++;
            }
            else
            {
                timer2.Stop();
            }
        }

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
            pictureBox2.BringToFront();
        }
    }
}
