using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace QLST
{
    public partial class frmMain : Form
    {
        DAL_Main dal_main = new DAL_Main();

        public frmMain()
        {
            InitializeComponent();
            txtNameNV.Text = dal_main.getNameNV(frmLogin.nhanVien.MANV);
            if (Program.frmHoaDon == null || Program.frmHoaDon.IsDisposed)
                Program.frmHoaDon = new frmHoaDon();
            Program.frmHoaDon.Dock = DockStyle.Fill;
            Program.frmHoaDon.TopLevel = false;
            dockContainerItem1.Control.Controls.Add(Program.frmHoaDon);
            Program.frmHoaDon.Show();
            this.MinimumSize = this.MaximumSize;
            phanQuyen();
        }

        private void logout(object sender, EventArgs e)
        {
            phanQuyen2();
            frmLogin.nhanVien = null;
            if (Program.frmLogin == null || Program.frmLogin.IsDisposed)
                Program.frmLogin = new frmLogin();
            this.Visible = false;
            Program.frmMain = null;
            Program.frmLogin.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void changePass(object sender, EventArgs e)
        {
            if (Program.frmDoiMatKhau == null || Program.frmDoiMatKhau.IsDisposed)
                Program.frmDoiMatKhau = new frmDoiMatKhau();
            Program.frmDoiMatKhau.ShowDialog();
        }
        
        private void openHoaDon(object sender, EventArgs e)
        {
            menuStrip2.Visible = true;
            for (int i = 0; i < tab.Items.Count; i++)
            {
                if (tab.Items[i].ToString() == "Hóa đơn")
                {
                    tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
                }
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Hóa đơn", "Hóa đơn");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.bill_icon;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Hóa đơn";
            item.Control = new Control();
            item.Control = panel;

            if (Program.frmHoaDon == null || Program.frmHoaDon.IsDisposed)
                Program.frmHoaDon = new frmHoaDon();
            Program.frmHoaDon.Dock = DockStyle.Fill;
            Program.frmHoaDon.TopLevel = false;
            item.Control.Controls.Add(Program.frmHoaDon);
            Program.frmHoaDon.Show();
            menuStrip2.Show();
        }

        private void openDanhMucMatHang(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            if (tab.Items[i].ToString() == "Danh mục mặt hàng")
            {
                tab.Items[i].Visible = true;
                menuStrip2.Show();
                return;
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục mặt hàng", "Danh mục mặt hàng");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.hang_hoa;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Danh mục mặt hàng";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmDanhMucMatHang == null || Program.frmDanhMucMatHang.IsDisposed)
                Program.frmDanhMucMatHang = new frmDanhMucMatHang();
            Program.frmDanhMucMatHang.Dock = DockStyle.Fill;
            Program.frmDanhMucMatHang.TopLevel = false;
            item.Control.Controls.Add(Program.frmDanhMucMatHang);
            Program.frmDanhMucMatHang.Show();
            menuStrip2.Show();
        }

        private void openDanhMucKhachHang(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            if (tab.Items[i].ToString() == "Danh mục khách hàng")
            {
                tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("", "Danh mục khách hàng");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.khach_hang_2;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Danh mục khách hàng";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmDanhMucKhachHang == null || Program.frmDanhMucKhachHang.IsDisposed)
                Program.frmDanhMucKhachHang = new frmDanhMucKhachHang();
            Program.frmDanhMucKhachHang.Dock = DockStyle.Fill;
            Program.frmDanhMucKhachHang.TopLevel = false;
            item.Control.Controls.Add(Program.frmDanhMucKhachHang);
            Program.frmDanhMucKhachHang.Show();
            menuStrip2.Show();
        }

        private void openDanhMucNhanVien(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            if (tab.Items[i].ToString() == "Danh mục nhân viên")
            {
                tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhân viên", "Danh mục nhân viên");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.nhan_vien;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Danh mục nhân viên";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmDanhMucNhanVien == null || Program.frmDanhMucNhanVien.IsDisposed)
                Program.frmDanhMucNhanVien = new frmDanhMucNhanVien();
            Program.frmDanhMucNhanVien.Dock = DockStyle.Fill;
            Program.frmDanhMucNhanVien.TopLevel = false;
            item.Control.Controls.Add(Program.frmDanhMucNhanVien);
            Program.frmDanhMucNhanVien.Show();
            menuStrip2.Show();
        }

        private void openThongKeHoaDon(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            if (tab.Items[i].ToString() == "Thống kê hóa đơn")
            {
                tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê hóa đơn", "Thống kê hóa đơn");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.thongkeHoaDon;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Thống kê hóa đơn";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmThongKeHoaDon == null || Program.frmThongKeHoaDon.IsDisposed)
                Program.frmThongKeHoaDon = new frmThongKeHoaDon();
            Program.frmThongKeHoaDon.Dock = DockStyle.Fill;
            Program.frmThongKeHoaDon.TopLevel = false;
            item.Control.Controls.Add(Program.frmThongKeHoaDon);
            Program.frmThongKeHoaDon.Show();
            menuStrip2.Show();
        }       

        private void bar2_DockTabClosed(object sender, DevComponents.DotNetBar.DockTabClosingEventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            if (tab.Items[i].ToString() == e.DockContainerItem.Text)
            {
                tab.Items[i].Visible = false;
                break;
            }
            e.Cancel = true;
            tab.Show();
            menuStrip2.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void danhMụcNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openDanhMucNhanVien(null, null);
        }

        private void pHÂNQUYỀNNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
            {
                if (tab.Items[i].ToString() == "PHÂN QUYỀN")
                {
                    tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
                }
            }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("PHÂN QUYỀN", "PHÂN QUYỀN");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.nhan_vien;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "PHÂN QUYỀN";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmPhanQuyen == null || Program.frmPhanQuyen.IsDisposed)
                Program.frmPhanQuyen = new frmPhanQuyen();
            Program.frmPhanQuyen.Dock = DockStyle.Fill;
            Program.frmPhanQuyen.TopLevel = false;
            item.Control.Controls.Add(Program.frmPhanQuyen);
            Program.frmPhanQuyen.Show();
            menuStrip2.Show();
        }

        private void phanQuyen() {
            string manv = frmLogin.nhanVien.MANV.Trim();
            var rs = Context.getInstance().getPhanQuyen(manv);
            foreach (var item in rs)
            {
                getPhanQuyenResult i = (getPhanQuyenResult)item;
                switch (i.maMH) {
                    case "frmBH":
                        btnHoaDon.Enabled = true;
                        break;
                    case "frmDM_KH":
                        danhMụcKháchHàngToolStripMenuItem.Enabled = true;
                        btnDanhMucKhachHang.Enabled = true;
                        break;
                    case "frmDM_MH":
                        daToolStripMenuItem.Enabled = true;
                        btnDanhMucMatHang.Enabled = true;
                        break;
                    case "frmDM_NV":
                        danhMụcNhânViênToolStripMenuItem1.Enabled = true;
                        btnDanhMucNhanVien.Enabled = true;
                        break;
                    case "frmHD":
                        bÁOCÁOQUỸToolStripMenuItem.Enabled = true;
                        btnThongKeHoaDon.Enabled = true;
                        break;

                }
            }
        }
        private void phanQuyen2()
        {
            btnHoaDon.Enabled = false;
            danhMụcKháchHàngToolStripMenuItem.Enabled = false;
            btnDanhMucKhachHang.Enabled = false;
            daToolStripMenuItem.Enabled = false;
            btnDanhMucMatHang.Enabled = false;
            danhMụcNhânViênToolStripMenuItem1.Enabled = false;
            btnDanhMucNhanVien.Enabled = false;
            bÁOCÁOQUỸToolStripMenuItem.Enabled = false;
            btnThongKeHoaDon.Enabled = false;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //phanQuyen();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //phanQuyen();
        }

        private void danhMụcNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Danh mục nhà cung cấp")
                {
                    tab.Items[i].Visible = true;
                    menuStrip2.Show();
                    return;
                }
            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhà cung cấp", "Danh mục nhà cung cấp");
            tab.Items.Add(item);
            Image a = global::QLST.Properties.Resources.Nhanvien_1;
            item.Image = a;
            item.Selected = true;
            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
            panel.Name = "Danh mục nhà cung cấp";
            item.Control = new Control();
            item.Control = panel;
            if (Program.frmDanhMucNhaCungCap == null || Program.frmDanhMucNhaCungCap.IsDisposed)
                Program.frmDanhMucNhaCungCap = new frmDanhMucNhaCungCap();
            Program.frmDanhMucNhaCungCap.Dock = DockStyle.Fill;
            Program.frmDanhMucNhaCungCap.TopLevel = false;
            item.Control.Controls.Add(Program.frmDanhMucNhaCungCap);
            Program.frmDanhMucNhaCungCap.Show();
            menuStrip2.Show();
        }
    }
}
