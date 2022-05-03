namespace GUI.UserControls
{
    partial class ucSanPham
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSanPham));
            this.lblGiaKM = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblSanCo = new System.Windows.Forms.Label();
            this.lblGiaGoc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblKM = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.picSP = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGiaKM
            // 
            this.lblGiaKM.AutoSize = true;
            this.lblGiaKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGiaKM.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblGiaKM.Location = new System.Drawing.Point(6, 120);
            this.lblGiaKM.Name = "lblGiaKM";
            this.lblGiaKM.Size = new System.Drawing.Size(94, 20);
            this.lblGiaKM.TabIndex = 18;
            this.lblGiaKM.Text = "Giá: 200vnd";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoEllipsis = true;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenSP.Location = new System.Drawing.Point(8, 105);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(130, 19);
            this.lblTenSP.TabIndex = 19;
            this.lblTenSP.Text = "Tên: Cafe";
            // 
            // lblSanCo
            // 
            this.lblSanCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblSanCo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSanCo.Location = new System.Drawing.Point(76, 142);
            this.lblSanCo.Name = "lblSanCo";
            this.lblSanCo.Size = new System.Drawing.Size(67, 18);
            this.lblSanCo.TabIndex = 20;
            this.lblSanCo.Text = "Sẵn có";
            this.lblSanCo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGiaGoc
            // 
            this.lblGiaGoc.AutoSize = true;
            this.lblGiaGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblGiaGoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGiaGoc.Location = new System.Drawing.Point(8, 140);
            this.lblGiaGoc.Name = "lblGiaGoc";
            this.lblGiaGoc.Size = new System.Drawing.Size(43, 13);
            this.lblGiaGoc.TabIndex = 21;
            this.lblGiaGoc.Text = "200vnd";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.lblKM);
            this.panel1.Location = new System.Drawing.Point(110, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 25);
            this.panel1.TabIndex = 23;
            // 
            // lblKM
            // 
            this.lblKM.BackColor = System.Drawing.Color.Transparent;
            this.lblKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lblKM.ForeColor = System.Drawing.Color.Gold;
            this.lblKM.Location = new System.Drawing.Point(1, 0);
            this.lblKM.Name = "lblKM";
            this.lblKM.Size = new System.Drawing.Size(32, 23);
            this.lblKM.TabIndex = 1;
            this.lblKM.Text = "km";
            this.lblKM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // picSP
            // 
            this.picSP.Image = global::GUI.Properties.Resources.cafe;
            this.picSP.Location = new System.Drawing.Point(10, 5);
            this.picSP.Name = "picSP";
            this.picSP.Size = new System.Drawing.Size(117, 101);
            this.picSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSP.TabIndex = 17;
            this.picSP.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(115, 118);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // ucSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblGiaKM);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.picSP);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblSanCo);
            this.Controls.Add(this.lblGiaGoc);
            this.Controls.Add(this.panel1);
            this.Name = "ucSanPham";
            this.Size = new System.Drawing.Size(150, 160);
            this.Load += new System.EventHandler(this.ucSanPham_Load);
            this.MouseEnter += new System.EventHandler(this.ucSanPham_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucSanPham_MouseLeave);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblGiaKM;
        public System.Windows.Forms.Label lblTenSP;
        public System.Windows.Forms.PictureBox picSP;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label lblSanCo;
        public System.Windows.Forms.Label lblGiaGoc;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblKM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
