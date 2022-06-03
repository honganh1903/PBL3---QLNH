namespace GUI.UserControls
{
    partial class ucKhachHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbbSearch = new System.Windows.Forms.ComboBox();
            this.btSAVE = new System.Windows.Forms.Button();
            this.cboxTinhTrang = new System.Windows.Forms.CheckBox();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.grbGioiTinh = new System.Windows.Forms.GroupBox();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.txtDoanhSo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lbTinhTrang = new System.Windows.Forms.Label();
            this.lbDoanhSo = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbNDK = new System.Windows.Forms.Label();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btNEW = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btEDIT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDaXoa = new System.Windows.Forms.Button();
            this.btHienTai = new System.Windows.Forms.Button();
            this.btAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.lbDSNow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grbGioiTinh.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cbbSearch);
            this.panel1.Controls.Add(this.btSAVE);
            this.panel1.Controls.Add(this.cboxTinhTrang);
            this.panel1.Controls.Add(this.dtpNgayDangKy);
            this.panel1.Controls.Add(this.grbGioiTinh);
            this.panel1.Controls.Add(this.txtDoanhSo);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtTenKH);
            this.panel1.Controls.Add(this.lbTinhTrang);
            this.panel1.Controls.Add(this.lbDoanhSo);
            this.panel1.Controls.Add(this.lbEmail);
            this.panel1.Controls.Add(this.lbNDK);
            this.panel1.Controls.Add(this.lbGioiTinh);
            this.panel1.Controls.Add(this.lbSDT);
            this.panel1.Controls.Add(this.lbDiaChi);
            this.panel1.Controls.Add(this.lbTenKH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 249);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 31);
            this.label1.TabIndex = 20;
            this.label1.Text = "Thông Tin Khách Hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(291, 202);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 26);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbbSearch
            // 
            this.cbbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearch.FormattingEnabled = true;
            this.cbbSearch.Location = new System.Drawing.Point(138, 200);
            this.cbbSearch.Name = "cbbSearch";
            this.cbbSearch.Size = new System.Drawing.Size(139, 28);
            this.cbbSearch.TabIndex = 17;
            // 
            // btSAVE
            // 
            this.btSAVE.BackColor = System.Drawing.Color.SlateGray;
            this.btSAVE.FlatAppearance.BorderSize = 0;
            this.btSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSAVE.ForeColor = System.Drawing.Color.White;
            this.btSAVE.Image = global::GUI.Properties.Resources.icons8_ok_32px3;
            this.btSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSAVE.Location = new System.Drawing.Point(537, 152);
            this.btSAVE.Name = "btSAVE";
            this.btSAVE.Size = new System.Drawing.Size(90, 35);
            this.btSAVE.TabIndex = 16;
            this.btSAVE.Text = "SAVE";
            this.btSAVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSAVE.UseVisualStyleBackColor = false;
            this.btSAVE.Click += new System.EventHandler(this.btSAVE_Click);
            // 
            // cboxTinhTrang
            // 
            this.cboxTinhTrang.AutoSize = true;
            this.cboxTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTinhTrang.Location = new System.Drawing.Point(432, 161);
            this.cboxTinhTrang.Name = "cboxTinhTrang";
            this.cboxTinhTrang.Size = new System.Drawing.Size(78, 24);
            this.cboxTinhTrang.TabIndex = 15;
            this.cboxTinhTrang.Text = "Đã xóa";
            this.cboxTinhTrang.UseVisualStyleBackColor = true;
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDangKy.Location = new System.Drawing.Point(432, 45);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(206, 26);
            this.dtpNgayDangKy.TabIndex = 14;
            // 
            // grbGioiTinh
            // 
            this.grbGioiTinh.Controls.Add(this.rbNu);
            this.grbGioiTinh.Controls.Add(this.rbNam);
            this.grbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGioiTinh.Location = new System.Drawing.Point(156, 146);
            this.grbGioiTinh.Name = "grbGioiTinh";
            this.grbGioiTinh.Size = new System.Drawing.Size(110, 36);
            this.grbGioiTinh.TabIndex = 13;
            this.grbGioiTinh.TabStop = false;
            this.grbGioiTinh.Text = "x";
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Location = new System.Drawing.Point(60, 13);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(47, 24);
            this.rbNu.TabIndex = 1;
            this.rbNu.TabStop = true;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Location = new System.Drawing.Point(7, 13);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(60, 24);
            this.rbNam.TabIndex = 0;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // txtDoanhSo
            // 
            this.txtDoanhSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhSo.Location = new System.Drawing.Point(432, 122);
            this.txtDoanhSo.Name = "txtDoanhSo";
            this.txtDoanhSo.Size = new System.Drawing.Size(206, 26);
            this.txtDoanhSo.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(432, 81);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 26);
            this.txtEmail.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(129, 119);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(171, 26);
            this.txtSDT.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(129, 81);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(171, 26);
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(129, 45);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(171, 26);
            this.txtTenKH.TabIndex = 8;
            // 
            // lbTinhTrang
            // 
            this.lbTinhTrang.AutoSize = true;
            this.lbTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTinhTrang.Location = new System.Drawing.Point(316, 162);
            this.lbTinhTrang.Name = "lbTinhTrang";
            this.lbTinhTrang.Size = new System.Drawing.Size(80, 20);
            this.lbTinhTrang.TabIndex = 7;
            this.lbTinhTrang.Text = "Tình trạng";
            // 
            // lbDoanhSo
            // 
            this.lbDoanhSo.AutoSize = true;
            this.lbDoanhSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhSo.Location = new System.Drawing.Point(316, 122);
            this.lbDoanhSo.Name = "lbDoanhSo";
            this.lbDoanhSo.Size = new System.Drawing.Size(78, 20);
            this.lbDoanhSo.TabIndex = 6;
            this.lbDoanhSo.Text = "Doanh số";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(316, 84);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(48, 20);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email";
            // 
            // lbNDK
            // 
            this.lbNDK.AutoSize = true;
            this.lbNDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNDK.Location = new System.Drawing.Point(316, 48);
            this.lbNDK.Name = "lbNDK";
            this.lbNDK.Size = new System.Drawing.Size(104, 20);
            this.lbNDK.TabIndex = 4;
            this.lbNDK.Text = "Ngày đăng ký";
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGioiTinh.Location = new System.Drawing.Point(3, 160);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(67, 20);
            this.lbGioiTinh.TabIndex = 3;
            this.lbGioiTinh.Text = "Giới tính";
            // 
            // lbSDT
            // 
            this.lbSDT.AutoSize = true;
            this.lbSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSDT.Location = new System.Drawing.Point(3, 122);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(102, 20);
            this.lbSDT.TabIndex = 2;
            this.lbSDT.Text = "Số điện thoại";
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiaChi.Location = new System.Drawing.Point(3, 84);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(57, 20);
            this.lbDiaChi.TabIndex = 1;
            this.lbDiaChi.Text = "Địa chỉ";
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKH.Location = new System.Drawing.Point(3, 48);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(128, 20);
            this.lbTenKH.TabIndex = 0;
            this.lbTenKH.Text = "Tên Khách Hàng";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.14286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.85714F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.73483F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.26517F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(910, 626);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(705, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 249);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btNEW);
            this.panel5.Controls.Add(this.btDel);
            this.panel5.Controls.Add(this.btEDIT);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(202, 218);
            this.panel5.TabIndex = 2;
            // 
            // btNEW
            // 
            this.btNEW.BackColor = System.Drawing.Color.SlateGray;
            this.btNEW.FlatAppearance.BorderSize = 0;
            this.btNEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNEW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNEW.ForeColor = System.Drawing.Color.White;
            this.btNEW.Image = global::GUI.Properties.Resources.icons8_add_32px_14;
            this.btNEW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNEW.Location = new System.Drawing.Point(43, 18);
            this.btNEW.Name = "btNEW";
            this.btNEW.Size = new System.Drawing.Size(115, 50);
            this.btNEW.TabIndex = 9;
            this.btNEW.Text = "NEW";
            this.btNEW.UseVisualStyleBackColor = false;
            this.btNEW.Click += new System.EventHandler(this.btNEW_Click);
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.SlateGray;
            this.btDel.FlatAppearance.BorderSize = 0;
            this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDel.ForeColor = System.Drawing.Color.White;
            this.btDel.Image = global::GUI.Properties.Resources.delete1;
            this.btDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDel.Location = new System.Drawing.Point(43, 74);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(115, 50);
            this.btDel.TabIndex = 11;
            this.btDel.Text = "DELETE";
            this.btDel.UseVisualStyleBackColor = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btEDIT
            // 
            this.btEDIT.BackColor = System.Drawing.Color.SlateGray;
            this.btEDIT.FlatAppearance.BorderSize = 0;
            this.btEDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEDIT.ForeColor = System.Drawing.Color.White;
            this.btEDIT.Image = global::GUI.Properties.Resources.edit;
            this.btEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEDIT.Location = new System.Drawing.Point(43, 128);
            this.btEDIT.Name = "btEDIT";
            this.btEDIT.Size = new System.Drawing.Size(115, 50);
            this.btEDIT.TabIndex = 10;
            this.btEDIT.Text = "EDIT";
            this.btEDIT.UseVisualStyleBackColor = false;
            this.btEDIT.Click += new System.EventHandler(this.btEDIT_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tính Năng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.btDaXoa);
            this.panel2.Controls.Add(this.btHienTai);
            this.panel2.Controls.Add(this.btAll);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(705, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 365);
            this.panel2.TabIndex = 1;
            // 
            // btDaXoa
            // 
            this.btDaXoa.BackColor = System.Drawing.Color.PowderBlue;
            this.btDaXoa.FlatAppearance.BorderSize = 0;
            this.btDaXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDaXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDaXoa.ForeColor = System.Drawing.Color.Black;
            this.btDaXoa.Location = new System.Drawing.Point(51, 199);
            this.btDaXoa.Name = "btDaXoa";
            this.btDaXoa.Size = new System.Drawing.Size(100, 50);
            this.btDaXoa.TabIndex = 12;
            this.btDaXoa.Text = "Đã xóa";
            this.btDaXoa.UseVisualStyleBackColor = false;
            this.btDaXoa.Click += new System.EventHandler(this.btDaXoa_Click);
            // 
            // btHienTai
            // 
            this.btHienTai.BackColor = System.Drawing.Color.PowderBlue;
            this.btHienTai.FlatAppearance.BorderSize = 0;
            this.btHienTai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHienTai.ForeColor = System.Drawing.Color.Black;
            this.btHienTai.Location = new System.Drawing.Point(51, 129);
            this.btHienTai.Name = "btHienTai";
            this.btHienTai.Size = new System.Drawing.Size(100, 50);
            this.btHienTai.TabIndex = 11;
            this.btHienTai.Text = "Hiện tại";
            this.btHienTai.UseVisualStyleBackColor = false;
            this.btHienTai.Click += new System.EventHandler(this.btHienTai_Click);
            // 
            // btAll
            // 
            this.btAll.BackColor = System.Drawing.Color.PowderBlue;
            this.btAll.FlatAppearance.BorderSize = 0;
            this.btAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAll.ForeColor = System.Drawing.Color.Black;
            this.btAll.Location = new System.Drawing.Point(51, 66);
            this.btAll.Name = "btAll";
            this.btAll.Size = new System.Drawing.Size(100, 45);
            this.btAll.TabIndex = 10;
            this.btAll.Text = "Toàn bộ";
            this.btAll.UseVisualStyleBackColor = false;
            this.btAll.Click += new System.EventHandler(this.btAll_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 41);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lựa chọn hiển thị";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.lbDSNow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(696, 365);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvKhachHang);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 41);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(696, 324);
            this.panel6.TabIndex = 2;
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 0);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(696, 324);
            this.dgvKhachHang.TabIndex = 1;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // lbDSNow
            // 
            this.lbDSNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
            this.lbDSNow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDSNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDSNow.ForeColor = System.Drawing.Color.White;
            this.lbDSNow.Location = new System.Drawing.Point(0, 0);
            this.lbDSNow.Name = "lbDSNow";
            this.lbDSNow.Size = new System.Drawing.Size(696, 41);
            this.lbDSNow.TabIndex = 1;
            this.lbDSNow.Text = "Danh sách khách hàng";
            this.lbDSNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tìm Kiếm";
            // 
            // ucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(910, 626);
            this.Load += new System.EventHandler(this.ucKhachHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbGioiTinh.ResumeLayout(false);
            this.grbGioiTinh.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbGioiTinh;
        private System.Windows.Forms.RadioButton rbNu;
        private System.Windows.Forms.RadioButton rbNam;
        private System.Windows.Forms.TextBox txtDoanhSo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lbTinhTrang;
        private System.Windows.Forms.Label lbDoanhSo;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbNDK;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.CheckBox cboxTinhTrang;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbbSearch;
        private System.Windows.Forms.Button btSAVE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btEDIT;
        private System.Windows.Forms.Button btNEW;
        private System.Windows.Forms.Button btDaXoa;
        private System.Windows.Forms.Button btHienTai;
        private System.Windows.Forms.Button btAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDSNow;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label label4;
    }
}
