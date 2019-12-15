namespace QLST
{
    partial class frmNhapHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPN = new System.Windows.Forms.Panel();
            this.btnThemPhieu = new System.Windows.Forms.Button();
            this.datePN = new System.Windows.Forms.DateTimePicker();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblMaDDH = new System.Windows.Forms.Label();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.panelSP = new System.Windows.Forms.Panel();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.dateHSD = new System.Windows.Forms.DateTimePicker();
            this.dateNSX = new System.Windows.Forms.DateTimePicker();
            this.cboSP = new System.Windows.Forms.ComboBox();
            this.lblHSD = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblNSX = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblSP = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGVSP = new System.Windows.Forms.DataGridView();
            this.MALO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MASP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HANSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONGNHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG_TRENQUAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONGIA_NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HANGHOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHIEUNHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panelPN.SuspendLayout();
            this.panelSP.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVSP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬP KHO";
            // 
            // panelPN
            // 
            this.panelPN.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelPN.Controls.Add(this.btnThemPhieu);
            this.panelPN.Controls.Add(this.datePN);
            this.panelPN.Controls.Add(this.txtMaDDH);
            this.panelPN.Controls.Add(this.txtMaPhieu);
            this.panelPN.Controls.Add(this.lblNgayLap);
            this.panelPN.Controls.Add(this.lblMaDDH);
            this.panelPN.Controls.Add(this.lblMaPhieu);
            this.panelPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPN.Location = new System.Drawing.Point(0, 43);
            this.panelPN.Name = "panelPN";
            this.panelPN.Size = new System.Drawing.Size(810, 93);
            this.panelPN.TabIndex = 1;
            // 
            // btnThemPhieu
            // 
            this.btnThemPhieu.Location = new System.Drawing.Point(685, 41);
            this.btnThemPhieu.Name = "btnThemPhieu";
            this.btnThemPhieu.Size = new System.Drawing.Size(102, 36);
            this.btnThemPhieu.TabIndex = 3;
            this.btnThemPhieu.Text = "Thêm phiếu";
            this.btnThemPhieu.UseVisualStyleBackColor = true;
            this.btnThemPhieu.Click += new System.EventHandler(this.btnThemPhieu_Click);
            // 
            // datePN
            // 
            this.datePN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePN.Location = new System.Drawing.Point(621, 7);
            this.datePN.Name = "datePN";
            this.datePN.Size = new System.Drawing.Size(166, 20);
            this.datePN.TabIndex = 2;
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.Enabled = false;
            this.txtMaDDH.Location = new System.Drawing.Point(383, 6);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.Size = new System.Drawing.Size(148, 20);
            this.txtMaDDH.TabIndex = 1;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Location = new System.Drawing.Point(97, 7);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(148, 20);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLap.Location = new System.Drawing.Point(552, 10);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(63, 16);
            this.lblNgayLap.TabIndex = 0;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // lblMaDDH
            // 
            this.lblMaDDH.AutoSize = true;
            this.lblMaDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDDH.Location = new System.Drawing.Point(269, 9);
            this.lblMaDDH.Name = "lblMaDDH";
            this.lblMaDDH.Size = new System.Drawing.Size(108, 16);
            this.lblMaDDH.TabIndex = 0;
            this.lblMaDDH.Text = "Mã đơn đặt hàng";
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieu.Location = new System.Drawing.Point(12, 10);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(63, 16);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "Mã phiếu";
            // 
            // panelSP
            // 
            this.panelSP.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSP.Controls.Add(this.btnXoaSP);
            this.panelSP.Controls.Add(this.btnThemSP);
            this.panelSP.Controls.Add(this.dateHSD);
            this.panelSP.Controls.Add(this.dateNSX);
            this.panelSP.Controls.Add(this.cboSP);
            this.panelSP.Controls.Add(this.lblHSD);
            this.panelSP.Controls.Add(this.lblDonGia);
            this.panelSP.Controls.Add(this.lblNSX);
            this.panelSP.Controls.Add(this.txtDonGia);
            this.panelSP.Controls.Add(this.txtSoLuong);
            this.panelSP.Controls.Add(this.lblSoLuong);
            this.panelSP.Controls.Add(this.lblSP);
            this.panelSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSP.Enabled = false;
            this.panelSP.Location = new System.Drawing.Point(0, 136);
            this.panelSP.Name = "panelSP";
            this.panelSP.Size = new System.Drawing.Size(810, 100);
            this.panelSP.TabIndex = 2;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(178, 71);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(75, 23);
            this.btnXoaSP.TabIndex = 4;
            this.btnXoaSP.Text = "Xoá";
            this.btnXoaSP.UseVisualStyleBackColor = true;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(97, 71);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(75, 23);
            this.btnThemSP.TabIndex = 4;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // dateHSD
            // 
            this.dateHSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHSD.Location = new System.Drawing.Point(621, 6);
            this.dateHSD.Name = "dateHSD";
            this.dateHSD.Size = new System.Drawing.Size(166, 20);
            this.dateHSD.TabIndex = 3;
            // 
            // dateNSX
            // 
            this.dateNSX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNSX.Location = new System.Drawing.Point(361, 6);
            this.dateNSX.Name = "dateNSX";
            this.dateNSX.Size = new System.Drawing.Size(148, 20);
            this.dateNSX.TabIndex = 3;
            // 
            // cboSP
            // 
            this.cboSP.FormattingEnabled = true;
            this.cboSP.Location = new System.Drawing.Point(97, 6);
            this.cboSP.Name = "cboSP";
            this.cboSP.Size = new System.Drawing.Size(148, 21);
            this.cboSP.TabIndex = 2;
            this.cboSP.DropDown += new System.EventHandler(this.cboSP_DropDown);
            // 
            // lblHSD
            // 
            this.lblHSD.AutoSize = true;
            this.lblHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSD.Location = new System.Drawing.Point(532, 10);
            this.lblHSD.Name = "lblHSD";
            this.lblHSD.Size = new System.Drawing.Size(83, 16);
            this.lblHSD.TabIndex = 0;
            this.lblHSD.Text = "Hạn sử dụng";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(297, 42);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(54, 16);
            this.lblDonGia.TabIndex = 0;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblNSX
            // 
            this.lblNSX.AutoSize = true;
            this.lblNSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNSX.Location = new System.Drawing.Point(265, 10);
            this.lblNSX.Name = "lblNSX";
            this.lblNSX.Size = new System.Drawing.Size(93, 16);
            this.lblNSX.TabIndex = 0;
            this.lblNSX.Text = "Ngày sản xuât";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(361, 39);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(148, 20);
            this.txtDonGia.TabIndex = 1;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(97, 39);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(148, 20);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(12, 42);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(61, 16);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSP.Location = new System.Drawing.Point(12, 10);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(69, 16);
            this.lblSP.TabIndex = 0;
            this.lblSP.Text = "Sản phẩm";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTongTien);
            this.panel4.Controls.Add(this.txtTongTien);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 431);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(810, 46);
            this.panel4.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(526, 17);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(73, 16);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(608, 14);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(179, 20);
            this.txtTongTien.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGVSP);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 236);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(810, 195);
            this.panel5.TabIndex = 4;
            // 
            // dataGVSP
            // 
            this.dataGVSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MALO,
            this.MASP,
            this.MAPN,
            this.NGAYSX,
            this.HANSD,
            this.SOLUONGNHAP,
            this.SOLUONG_TRENQUAY,
            this.DONGIA_NHAP,
            this.TENSP,
            this.HANGHOA,
            this.PHIEUNHAP});
            this.dataGVSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGVSP.Location = new System.Drawing.Point(0, 0);
            this.dataGVSP.Name = "dataGVSP";
            this.dataGVSP.Size = new System.Drawing.Size(810, 195);
            this.dataGVSP.TabIndex = 0;
            // 
            // MALO
            // 
            this.MALO.DataPropertyName = "MALO";
            this.MALO.HeaderText = "Mã lô hàng";
            this.MALO.Name = "MALO";
            this.MALO.Visible = false;
            // 
            // MASP
            // 
            this.MASP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MASP.DataPropertyName = "MASP";
            this.MASP.HeaderText = "Mã sản phẩm";
            this.MASP.Name = "MASP";
            // 
            // MAPN
            // 
            this.MAPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MAPN.DataPropertyName = "MAPN";
            this.MAPN.HeaderText = "Mã phiếu nhập";
            this.MAPN.Name = "MAPN";
            this.MAPN.Visible = false;
            this.MAPN.Width = 103;
            // 
            // NGAYSX
            // 
            this.NGAYSX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NGAYSX.DataPropertyName = "NGAYSX";
            this.NGAYSX.HeaderText = "Ngày sản xuất";
            this.NGAYSX.Name = "NGAYSX";
            this.NGAYSX.ReadOnly = true;
            // 
            // HANSD
            // 
            this.HANSD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HANSD.DataPropertyName = "HANSD";
            this.HANSD.HeaderText = "Hạn sử dụng";
            this.HANSD.Name = "HANSD";
            this.HANSD.ReadOnly = true;
            // 
            // SOLUONGNHAP
            // 
            this.SOLUONGNHAP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SOLUONGNHAP.DataPropertyName = "SOLUONGNHAP";
            this.SOLUONGNHAP.HeaderText = "Số lượng nhập";
            this.SOLUONGNHAP.Name = "SOLUONGNHAP";
            this.SOLUONGNHAP.ReadOnly = true;
            // 
            // SOLUONG_TRENQUAY
            // 
            this.SOLUONG_TRENQUAY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SOLUONG_TRENQUAY.DataPropertyName = "SOLUONG_TRENQUAY";
            this.SOLUONG_TRENQUAY.HeaderText = "Số lượng quầy";
            this.SOLUONG_TRENQUAY.Name = "SOLUONG_TRENQUAY";
            this.SOLUONG_TRENQUAY.ReadOnly = true;
            this.SOLUONG_TRENQUAY.Visible = false;
            // 
            // DONGIA_NHAP
            // 
            this.DONGIA_NHAP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DONGIA_NHAP.DataPropertyName = "DONGIA_NHAP";
            this.DONGIA_NHAP.HeaderText = "Đơn giá";
            this.DONGIA_NHAP.Name = "DONGIA_NHAP";
            this.DONGIA_NHAP.ReadOnly = true;
            // 
            // TENSP
            // 
            this.TENSP.DataPropertyName = "TENSP";
            this.TENSP.HeaderText = "Tên sản phẩm";
            this.TENSP.Name = "TENSP";
            this.TENSP.ReadOnly = true;
            this.TENSP.Visible = false;
            // 
            // HANGHOA
            // 
            this.HANGHOA.DataPropertyName = "HANGHOA";
            this.HANGHOA.HeaderText = "Hàng hóa";
            this.HANGHOA.Name = "HANGHOA";
            this.HANGHOA.ReadOnly = true;
            this.HANGHOA.Visible = false;
            // 
            // PHIEUNHAP
            // 
            this.PHIEUNHAP.DataPropertyName = "PHIEUNHAP";
            this.PHIEUNHAP.HeaderText = "Phiếu nhập";
            this.PHIEUNHAP.Name = "PHIEUNHAP";
            this.PHIEUNHAP.ReadOnly = true;
            this.PHIEUNHAP.Visible = false;
            // 
            // frmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 477);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelSP);
            this.Controls.Add(this.panelPN);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.frmNhapHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPN.ResumeLayout(false);
            this.panelPN.PerformLayout();
            this.panelSP.ResumeLayout(false);
            this.panelSP.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPN;
        private System.Windows.Forms.Button btnThemPhieu;
        private System.Windows.Forms.DateTimePicker datePN;
        private System.Windows.Forms.TextBox txtMaDDH;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblMaDDH;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Panel panelSP;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGVSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.DateTimePicker dateHSD;
        private System.Windows.Forms.DateTimePicker dateNSX;
        private System.Windows.Forms.ComboBox cboSP;
        private System.Windows.Forms.Label lblHSD;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblNSX;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MALO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn HANSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONGNHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG_TRENQUAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONGIA_NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HANGHOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHIEUNHAP;
    }
}