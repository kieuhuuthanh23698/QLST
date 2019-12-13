namespace QLST
{
    partial class frmDanhMucMatHang
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnThemLoaiMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.btnXoaLoaiMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.btnSuaLoaiMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnThemMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.btnXoaMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.btnSuaMatHang = new DevComponents.DotNetBar.ButtonItem();
            this.btnThemHangVaoKho = new DevComponents.DotNetBar.ButtonItem();
            this.treeViewLoaiMatHang = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MASP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA_BAN_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewLoaiMatHang)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnThemLoaiMatHang,
            this.btnXoaLoaiMatHang,
            this.btnSuaLoaiMatHang});
            this.bar1.Location = new System.Drawing.Point(12, 105);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(307, 41);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnThemLoaiMatHang
            // 
            this.btnThemLoaiMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThemLoaiMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnThemLoaiMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemLoaiMatHang.Image = global::QLST.Properties.Resources.them_icon;
            this.btnThemLoaiMatHang.Name = "btnThemLoaiMatHang";
            this.btnThemLoaiMatHang.Text = "Thêm";
            this.btnThemLoaiMatHang.Click += new System.EventHandler(this.btnThemLoaiMatHang_Click);
            // 
            // btnXoaLoaiMatHang
            // 
            this.btnXoaLoaiMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnXoaLoaiMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnXoaLoaiMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaLoaiMatHang.Image = global::QLST.Properties.Resources.xoa_icon;
            this.btnXoaLoaiMatHang.Name = "btnXoaLoaiMatHang";
            this.btnXoaLoaiMatHang.Text = "Xóa";
            this.btnXoaLoaiMatHang.Click += new System.EventHandler(this.btnXoaLoaiMatHang_Click);
            // 
            // btnSuaLoaiMatHang
            // 
            this.btnSuaLoaiMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSuaLoaiMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSuaLoaiMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaLoaiMatHang.Image = global::QLST.Properties.Resources.sua_icon;
            this.btnSuaLoaiMatHang.Name = "btnSuaLoaiMatHang";
            this.btnSuaLoaiMatHang.Text = "Sửa";
            this.btnSuaLoaiMatHang.Click += new System.EventHandler(this.btnSuaLoaiMatHang_Click);
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnThemMatHang,
            this.btnXoaMatHang,
            this.btnSuaMatHang,
            this.btnThemHangVaoKho});
            this.bar2.Location = new System.Drawing.Point(393, 105);
            this.bar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(576, 41);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 7;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnThemMatHang
            // 
            this.btnThemMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThemMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnThemMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMatHang.Image = global::QLST.Properties.Resources.them_icon;
            this.btnThemMatHang.Name = "btnThemMatHang";
            this.btnThemMatHang.Text = "Thêm";
            this.btnThemMatHang.Click += new System.EventHandler(this.btnThemMatHang_Click);
            // 
            // btnXoaMatHang
            // 
            this.btnXoaMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnXoaMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnXoaMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMatHang.Image = global::QLST.Properties.Resources.xoa_icon;
            this.btnXoaMatHang.Name = "btnXoaMatHang";
            this.btnXoaMatHang.Text = "Xóa";
            this.btnXoaMatHang.Click += new System.EventHandler(this.btnXoaMatHang_Click);
            // 
            // btnSuaMatHang
            // 
            this.btnSuaMatHang.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSuaMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSuaMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaMatHang.Image = global::QLST.Properties.Resources.sua_icon;
            this.btnSuaMatHang.Name = "btnSuaMatHang";
            this.btnSuaMatHang.Text = "Sửa";
            this.btnSuaMatHang.Click += new System.EventHandler(this.btnSuaMatHang_Click);
            // 
            // btnThemHangVaoKho
            // 
            this.btnThemHangVaoKho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThemHangVaoKho.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnThemHangVaoKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemHangVaoKho.Image = global::QLST.Properties.Resources.themHangVaoKho2_icon;
            this.btnThemHangVaoKho.Name = "btnThemHangVaoKho";
            this.btnThemHangVaoKho.Text = "Thêm hàng vào kho";
            this.btnThemHangVaoKho.Click += new System.EventHandler(this.btnThemHangVaoKho_Click);
            // 
            // treeViewLoaiMatHang
            // 
            this.treeViewLoaiMatHang.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeViewLoaiMatHang.AllowDrop = true;
            this.treeViewLoaiMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewLoaiMatHang.BackColor = System.Drawing.Color.Azure;
            // 
            // 
            // 
            this.treeViewLoaiMatHang.BackgroundStyle.Class = "TreeBorderKey";
            this.treeViewLoaiMatHang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeViewLoaiMatHang.Location = new System.Drawing.Point(17, 175);
            this.treeViewLoaiMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewLoaiMatHang.Name = "treeViewLoaiMatHang";
            this.treeViewLoaiMatHang.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.treeViewLoaiMatHang.NodesConnector = this.nodeConnector1;
            this.treeViewLoaiMatHang.NodeStyle = this.elementStyle1;
            this.treeViewLoaiMatHang.PathSeparator = ";";
            this.treeViewLoaiMatHang.Size = new System.Drawing.Size(307, 486);
            this.treeViewLoaiMatHang.Styles.Add(this.elementStyle1);
            this.treeViewLoaiMatHang.TabIndex = 8;
            this.treeViewLoaiMatHang.Text = "advTree1";
            this.treeViewLoaiMatHang.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treeViewLoaiMatHang_NodeClick);
            // 
            // node1
            // 
            this.node1.Name = "node1";
            this.node1.Text = "Tất cả loại hàng hóa";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Location = new System.Drawing.Point(16, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(953, 87);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 104;
            // 
            // labelX2
            // 
            this.labelX2.BackgroundImage = global::QLST.Properties.Resources.mathang_1;
            this.labelX2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(4, 4);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(121, 84);
            this.labelX2.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX1.Location = new System.Drawing.Point(295, 23);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(331, 47);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "DANH MỤC MẶT HÀNG";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridViewX1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASP,
            this.TENSP,
            this.Column5,
            this.dataGridViewTextBoxColumn3,
            this.GIA_BAN_1,
            this.dataGridViewTextBoxColumn4,
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
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(394, 175);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(576, 486);
            this.dataGridViewX1.TabIndex = 105;
            // 
            // MASP
            // 
            this.MASP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MASP.DataPropertyName = "MASP";
            this.MASP.FillWeight = 55.27919F;
            this.MASP.HeaderText = "Mã hàng hóa";
            this.MASP.Name = "MASP";
            this.MASP.ReadOnly = true;
            this.MASP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TENSP
            // 
            this.TENSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TENSP.DataPropertyName = "TENSP";
            this.TENSP.FillWeight = 140F;
            this.TENSP.HeaderText = "Tên hàng hóa";
            this.TENSP.Name = "TENSP";
            this.TENSP.ReadOnly = true;
            this.TENSP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "GIA_BAN";
            this.Column5.HeaderText = "Giá bán";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "GIAMGIA";
            this.dataGridViewTextBoxColumn3.FillWeight = 90F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Khuyến mãi         (-%)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GIA_BAN_1
            // 
            this.GIA_BAN_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GIA_BAN_1.DataPropertyName = "GIA_BAN_1";
            this.GIA_BAN_1.FillWeight = 60F;
            this.GIA_BAN_1.HeaderText = "Giá bán(-%)";
            this.GIA_BAN_1.Name = "GIA_BAN_1";
            this.GIA_BAN_1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DVT";
            this.dataGridViewTextBoxColumn4.FillWeight = 36.85279F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn vị";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
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
            // frmDanhMucMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QLST.Properties.Resources.bg_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(981, 681);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.treeViewLoaiMatHang);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.bar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDanhMucMatHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục mặt hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewLoaiMatHang)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnThemLoaiMatHang;
        private DevComponents.DotNetBar.ButtonItem btnXoaLoaiMatHang;
        private DevComponents.DotNetBar.ButtonItem btnSuaLoaiMatHang;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnThemMatHang;
        private DevComponents.DotNetBar.ButtonItem btnXoaMatHang;
        private DevComponents.DotNetBar.ButtonItem btnSuaMatHang;
        private DevComponents.DotNetBar.ButtonItem btnThemHangVaoKho;
        private DevComponents.AdvTree.AdvTree treeViewLoaiMatHang;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA_BAN_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}