namespace QLST
{
    partial class frmThemNhomMatHang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNhomMatHang));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNhomMatHang = new System.Windows.Forms.TextBox();
            this.btnThemNhomMatHang = new DevComponents.DotNetBar.ButtonX();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtMaNhomMatHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên nhóm mặt hàng";
            // 
            // txtTenNhomMatHang
            // 
            this.txtTenNhomMatHang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhomMatHang.Location = new System.Drawing.Point(205, 174);
            this.txtTenNhomMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenNhomMatHang.Name = "txtTenNhomMatHang";
            this.txtTenNhomMatHang.Size = new System.Drawing.Size(260, 27);
            this.txtTenNhomMatHang.TabIndex = 2;
            this.txtTenNhomMatHang.TextChanged += new System.EventHandler(this.txtTenNhomMatHang_TextChanged);
            this.txtTenNhomMatHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNhomMatHang_KeyPress);
            // 
            // btnThemNhomMatHang
            // 
            this.btnThemNhomMatHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThemNhomMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThemNhomMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhomMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhomMatHang.Location = new System.Drawing.Point(205, 214);
            this.btnThemNhomMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemNhomMatHang.Name = "btnThemNhomMatHang";
            this.btnThemNhomMatHang.Size = new System.Drawing.Size(117, 30);
            this.btnThemNhomMatHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThemNhomMatHang.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.btnThemNhomMatHang.Symbol = "";
            this.btnThemNhomMatHang.TabIndex = 7;
            this.btnThemNhomMatHang.Text = "Thêm";
            this.btnThemNhomMatHang.Click += new System.EventHandler(this.btnThemNhomMatHang_Click);
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.Name = "itemContainer1";
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(351, 214);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 30);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.Symbol = "";
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(501, 92);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelX2.Location = new System.Drawing.Point(192, 32);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(275, 28);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "THÊM NHÓM MẶT HÀNG";
            // 
            // labelX1
            // 
            this.labelX1.BackgroundImage = global::QLST.Properties.Resources.Sao_2;
            this.labelX1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX1.Size = new System.Drawing.Size(127, 89);
            this.labelX1.TabIndex = 0;
            // 
            // txtMaNhomMatHang
            // 
            this.txtMaNhomMatHang.Enabled = false;
            this.txtMaNhomMatHang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhomMatHang.Location = new System.Drawing.Point(205, 120);
            this.txtMaNhomMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNhomMatHang.Name = "txtMaNhomMatHang";
            this.txtMaNhomMatHang.Size = new System.Drawing.Size(260, 27);
            this.txtMaNhomMatHang.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã nhóm mặt hàng";
            // 
            // frmThemNhomMatHang
            // 
            this.AcceptButton = this.btnThemNhomMatHang;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLST.Properties.Resources.bg_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(501, 278);
            this.Controls.Add(this.txtMaNhomMatHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThemNhomMatHang);
            this.Controls.Add(this.txtTenNhomMatHang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmThemNhomMatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÓM MẶT HÀNG - THÊM MỚI";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNhomMatHang;
        private DevComponents.DotNetBar.ButtonX btnThemNhomMatHang;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private System.Windows.Forms.TextBox txtMaNhomMatHang;
        private System.Windows.Forms.Label label2;
    }
}