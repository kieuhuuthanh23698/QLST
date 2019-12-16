namespace QLST
{
    partial class frmDatHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tất cả loại hàng hóa");
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGiamSoLuong = new DevComponents.DotNetBar.ButtonX();
            this.btnTangSoLuong = new DevComponents.DotNetBar.ButtonX();
            this.btnXoaHangTrongGio = new DevComponents.DotNetBar.ButtonX();
            this.numericGiam = new System.Windows.Forms.NumericUpDown();
            this.numericTang = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstGioHang = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridViewHangHoa = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA_BAN_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemHangHoaVaoGio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.autoCompleteTextTenHangHoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbNhaCungCap = new System.Windows.Forms.ComboBox();
            this.numericThem = new System.Windows.Forms.NumericUpDown();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnThanhToan = new DevComponents.DotNetBar.ButtonX();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.dtp_ngaylap = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numericGiam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThem)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SỐ LƯỢNG";
            this.columnHeader4.Width = 100;
            // 
            // btnGiamSoLuong
            // 
            this.btnGiamSoLuong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGiamSoLuong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGiamSoLuong.Location = new System.Drawing.Point(18, 99);
            this.btnGiamSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiamSoLuong.Name = "btnGiamSoLuong";
            this.btnGiamSoLuong.Size = new System.Drawing.Size(22, 18);
            this.btnGiamSoLuong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGiamSoLuong.TabIndex = 112;
            this.btnGiamSoLuong.Text = "-";
            // 
            // btnTangSoLuong
            // 
            this.btnTangSoLuong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTangSoLuong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTangSoLuong.Location = new System.Drawing.Point(18, 63);
            this.btnTangSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.btnTangSoLuong.Name = "btnTangSoLuong";
            this.btnTangSoLuong.Size = new System.Drawing.Size(22, 18);
            this.btnTangSoLuong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTangSoLuong.TabIndex = 111;
            this.btnTangSoLuong.Text = "+";
            // 
            // btnXoaHangTrongGio
            // 
            this.btnXoaHangTrongGio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaHangTrongGio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaHangTrongGio.Location = new System.Drawing.Point(18, 10);
            this.btnXoaHangTrongGio.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaHangTrongGio.Name = "btnXoaHangTrongGio";
            this.btnXoaHangTrongGio.Size = new System.Drawing.Size(76, 40);
            this.btnXoaHangTrongGio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoaHangTrongGio.TabIndex = 110;
            this.btnXoaHangTrongGio.Text = "Xóa";
            // 
            // numericGiam
            // 
            this.numericGiam.Location = new System.Drawing.Point(50, 99);
            this.numericGiam.Margin = new System.Windows.Forms.Padding(2);
            this.numericGiam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGiam.Name = "numericGiam";
            this.numericGiam.Size = new System.Drawing.Size(45, 20);
            this.numericGiam.TabIndex = 31;
            this.numericGiam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericTang
            // 
            this.numericTang.Location = new System.Drawing.Point(50, 63);
            this.numericTang.Margin = new System.Windows.Forms.Padding(2);
            this.numericTang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTang.Name = "numericTang";
            this.numericTang.Size = new System.Drawing.Size(45, 20);
            this.numericTang.TabIndex = 30;
            this.numericTang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(548, 104);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 145;
            this.label14.Text = "NHÀ CUNG CẤP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnGiamSoLuong);
            this.panel1.Controls.Add(this.btnTangSoLuong);
            this.panel1.Controls.Add(this.btnXoaHangTrongGio);
            this.panel1.Controls.Add(this.numericGiam);
            this.panel1.Controls.Add(this.numericTang);
            this.panel1.Location = new System.Drawing.Point(490, 537);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 132);
            this.panel1.TabIndex = 146;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "MASP";
            this.columnHeader8.Width = 0;
            // 
            // lstGioHang
            // 
            this.lstGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGioHang.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lstGioHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader8});
            this.lstGioHang.FullRowSelect = true;
            this.lstGioHang.GridLines = true;
            this.lstGioHang.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstGioHang.LabelWrap = false;
            this.lstGioHang.Location = new System.Drawing.Point(552, 193);
            this.lstGioHang.Margin = new System.Windows.Forms.Padding(2);
            this.lstGioHang.Name = "lstGioHang";
            this.lstGioHang.ShowGroups = false;
            this.lstGioHang.Size = new System.Drawing.Size(452, 288);
            this.lstGioHang.TabIndex = 143;
            this.lstGioHang.UseCompatibleStateImageBehavior = false;
            this.lstGioHang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TÊN HÀNG";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MÃ HÀNG";
            this.columnHeader7.Width = 82;
            // 
            // dataGridViewHangHoa
            // 
            this.dataGridViewHangHoa.AllowUserToAddRows = false;
            this.dataGridViewHangHoa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewHangHoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHangHoa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewHangHoa.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridViewHangHoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHangHoa,
            this.TenHangHoa,
            this.Column5,
            this.GiaBan,
            this.GIA_BAN_1,
            this.DonVi,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHangHoa.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewHangHoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewHangHoa.Location = new System.Drawing.Point(26, 297);
            this.dataGridViewHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewHangHoa.Name = "dataGridViewHangHoa";
            this.dataGridViewHangHoa.ReadOnly = true;
            this.dataGridViewHangHoa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewHangHoa.RowHeadersVisible = false;
            this.dataGridViewHangHoa.RowTemplate.Height = 24;
            this.dataGridViewHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHangHoa.Size = new System.Drawing.Size(432, 372);
            this.dataGridViewHangHoa.TabIndex = 147;
            this.dataGridViewHangHoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHangHoa_CellDoubleClick);
            // 
            // MaHangHoa
            // 
            this.MaHangHoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaHangHoa.DataPropertyName = "MASP";
            this.MaHangHoa.FillWeight = 55.27919F;
            this.MaHangHoa.HeaderText = "Mã hàng hóa";
            this.MaHangHoa.Name = "MaHangHoa";
            this.MaHangHoa.ReadOnly = true;
            this.MaHangHoa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TenHangHoa
            // 
            this.TenHangHoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenHangHoa.DataPropertyName = "TENSP";
            this.TenHangHoa.FillWeight = 140F;
            this.TenHangHoa.HeaderText = "Tên hàng hóa";
            this.TenHangHoa.Name = "TenHangHoa";
            this.TenHangHoa.ReadOnly = true;
            this.TenHangHoa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "GIA_BAN";
            this.Column5.HeaderText = "Giá bán";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // GiaBan
            // 
            this.GiaBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GiaBan.DataPropertyName = "GIAMGIA";
            this.GiaBan.FillWeight = 90F;
            this.GiaBan.HeaderText = "Khuyến mãi         (-%)";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GIA_BAN_1
            // 
            this.GIA_BAN_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GIA_BAN_1.DataPropertyName = "GIA_BAN_1";
            this.GIA_BAN_1.FillWeight = 60F;
            this.GIA_BAN_1.HeaderText = "Giá bán";
            this.GIA_BAN_1.Name = "GIA_BAN_1";
            this.GIA_BAN_1.ReadOnly = true;
            // 
            // DonVi
            // 
            this.DonVi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonVi.DataPropertyName = "DVT";
            this.DonVi.FillWeight = 36.85279F;
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "SOLUONG";
            this.Column1.FillWeight = 36.85279F;
            this.Column1.HeaderText = "Số lượng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DANHMUC";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MALOAI";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DANH_MUC_SP";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "HIDDEN";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHoaDon.Enabled = false;
            this.txtMaHoaDon.Location = new System.Drawing.Point(645, 62);
            this.txtMaHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(154, 20);
            this.txtMaHoaDon.TabIndex = 141;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(549, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 140;
            this.label5.Text = "MÃ ĐĐH";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(821, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "NGÀY";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(686, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 31);
            this.label3.TabIndex = 138;
            this.label3.Text = "ĐƠN ĐẶT HÀNG";
            // 
            // btnThemHangHoaVaoGio
            // 
            this.btnThemHangHoaVaoGio.Location = new System.Drawing.Point(402, 24);
            this.btnThemHangHoaVaoGio.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemHangHoaVaoGio.Name = "btnThemHangHoaVaoGio";
            this.btnThemHangHoaVaoGio.Size = new System.Drawing.Size(56, 28);
            this.btnThemHangHoaVaoGio.TabIndex = 137;
            this.btnThemHangHoaVaoGio.Text = "Thêm";
            this.btnThemHangHoaVaoGio.UseVisualStyleBackColor = true;
            this.btnThemHangHoaVaoGio.Click += new System.EventHandler(this.btnThemHangHoaVaoGio_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(268, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 136;
            this.label2.Text = "Số lượng :";
            // 
            // autoCompleteTextTenHangHoa
            // 
            this.autoCompleteTextTenHangHoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.autoCompleteTextTenHangHoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.autoCompleteTextTenHangHoa.Location = new System.Drawing.Point(90, 29);
            this.autoCompleteTextTenHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.autoCompleteTextTenHangHoa.Name = "autoCompleteTextTenHangHoa";
            this.autoCompleteTextTenHangHoa.Size = new System.Drawing.Size(175, 20);
            this.autoCompleteTextTenHangHoa.TabIndex = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 134;
            this.label1.Text = "Tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(549, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 142;
            this.label6.Text = "GHI CHÚ";
            // 
            // cbbNhaCungCap
            // 
            this.cbbNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhaCungCap.FormattingEnabled = true;
            this.cbbNhaCungCap.Location = new System.Drawing.Point(645, 101);
            this.cbbNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.cbbNhaCungCap.Name = "cbbNhaCungCap";
            this.cbbNhaCungCap.Size = new System.Drawing.Size(154, 21);
            this.cbbNhaCungCap.TabIndex = 152;
            // 
            // numericThem
            // 
            this.numericThem.Location = new System.Drawing.Point(342, 29);
            this.numericThem.Margin = new System.Windows.Forms.Padding(2);
            this.numericThem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThem.Name = "numericThem";
            this.numericThem.Size = new System.Drawing.Size(52, 20);
            this.numericThem.TabIndex = 151;
            this.numericThem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Azure;
            this.treeView1.Location = new System.Drawing.Point(26, 63);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Tất cả loại hàng hóa";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(433, 211);
            this.treeView1.TabIndex = 150;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThanhToan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThanhToan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThanhToan.Image = global::QLST.Properties.Resources.shop_cart_icon;
            this.btnThanhToan.ImageFixedSize = new System.Drawing.Size(128, 128);
            this.btnThanhToan.Location = new System.Drawing.Point(890, 544);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnThanhToan.Size = new System.Drawing.Size(113, 124);
            this.btnThanhToan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThanhToan.TabIndex = 149;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(645, 138);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(359, 50);
            this.txtGhiChu.TabIndex = 153;
            this.txtGhiChu.Text = "";
            // 
            // dtp_ngaylap
            // 
            this.dtp_ngaylap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_ngaylap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaylap.Location = new System.Drawing.Point(864, 59);
            this.dtp_ngaylap.Name = "dtp_ngaylap";
            this.dtp_ngaylap.Size = new System.Drawing.Size(140, 20);
            this.dtp_ngaylap.TabIndex = 154;
            // 
            // frmDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLST.Properties.Resources.bg_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 691);
            this.Controls.Add(this.dtp_ngaylap);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstGioHang);
            this.Controls.Add(this.dataGridViewHangHoa);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemHangHoaVaoGio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoCompleteTextTenHangHoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbNhaCungCap);
            this.Controls.Add(this.numericThem);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnThanhToan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDatHang";
            this.Text = "frmDatHang";
            this.Load += new System.EventHandler(this.frmDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericGiam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTang)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevComponents.DotNetBar.ButtonX btnGiamSoLuong;
        private DevComponents.DotNetBar.ButtonX btnTangSoLuong;
        private DevComponents.DotNetBar.ButtonX btnXoaHangTrongGio;
        private System.Windows.Forms.NumericUpDown numericGiam;
        private System.Windows.Forms.NumericUpDown numericTang;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView lstGioHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA_BAN_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemHangHoaVaoGio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox autoCompleteTextTenHangHoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbNhaCungCap;
        private System.Windows.Forms.NumericUpDown numericThem;
        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.ButtonX btnThanhToan;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.DateTimePicker dtp_ngaylap;
    }
}