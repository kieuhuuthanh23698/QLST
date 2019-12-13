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
    public partial class frmDanhMucMatHang : Form
    {
        DAL_HoaDon dal = new DAL_HoaDon();
        DAL_HangHoa dal_hanghoa = new DAL_HangHoa();
        List<DANH_MUC_SP> danhMucHangHoa;
        List<HANGHOA> dsHangHoa;
        ImageList im = new ImageList();

        public frmDanhMucMatHang()
        {
            im.Images.Add(QLST.Properties.Resources.father_node);
            im.Images.Add(QLST.Properties.Resources.child_node);
            InitializeComponent();
            danhMucHangHoa = dal.getDanhMuc();
            dsHangHoa = dal.getHangHoa("");
            taiGridViewHangHoa();
            taiTreeViewNhomMatHang();
        }

        public void taiGridViewHangHoa()
        {
            try
            {
                dataGridViewX1.DataSource = dsHangHoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void taiTreeViewNhomMatHang()
        {
            treeViewLoaiMatHang.Nodes[0].Nodes.Clear();
            try
            {
                int i = 0;
                foreach (var item in danhMucHangHoa)
                {
                    treeViewLoaiMatHang.Nodes[0].Nodes.Add(new DevComponents.AdvTree.Node(item.TENLOAI));
                    treeViewLoaiMatHang.Nodes[0].Nodes[i++].ImageIndex = 1;
                }
                treeViewLoaiMatHang.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void treeViewLoaiMatHang_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            try
            {
                if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                    taiGridViewHangHoa();
                else
                    dataGridViewX1.DataSource = dal.getHangHoa(e.Node.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     

        private void btnThemLoaiMatHang_Click(object sender, EventArgs e)
        {
            Program.frmThemNhomMatHang = new frmThemNhomMatHang();
            DialogResult rs = Program.frmThemNhomMatHang.ShowDialog();
            if (rs == DialogResult.OK)
            {
                refreshData();
            }
        }

        private void btnXoaLoaiMatHang_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.AdvTree.Node node = treeViewLoaiMatHang.SelectedNode;
                if (node == treeViewLoaiMatHang.Nodes[0])
                    return;
                if (node != null)
                {
                    string tenLoaiHangHoaCanXoa = node.Text;
                    int kq = dal_hanghoa.canDelete(tenLoaiHangHoaCanXoa);
                    if (kq == 0)
                    {
                        MessageBox.Show("Đã xóa nhóm mặt hàng " + tenLoaiHangHoaCanXoa, "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshData();
                    }
                    if(kq > 0){
                        MessageBox.Show("Nhóm mặt hàng " + tenLoaiHangHoaCanXoa + " có " + kq + " sản phẩm !\nĐã ẩn nhóm mặt hàng !","Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshData();
                    }
                    if (kq == -1)
                    {
                        MessageBox.Show("Xóa nhóm mặt hàng thất bại !", "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (kq == -2)
                    {
                        MessageBox.Show("Nhóm mặt hàng này vẫn còn hàng hóa trong kho !", "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaLoaiMatHang_Click(object sender, EventArgs e)
        {
            if (treeViewLoaiMatHang.SelectedNode != null)
            {
                if (treeViewLoaiMatHang.SelectedNode != treeViewLoaiMatHang.Nodes[0])
                {
                    string ten = treeViewLoaiMatHang.SelectedNode.Text;
                    Program.frmDoiTenNhomMatHang = new frmDoiTenNhomMatHang(ten);
                    DialogResult rs = Program.frmDoiTenNhomMatHang.ShowDialog();
                    if (rs == DialogResult.OK)
                        refreshData();
                }
            }
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            Program.frmThemSanPham = new frmThemSanPham();
            DialogResult rs = Program.frmThemSanPham.ShowDialog();
            if(rs == DialogResult.OK)
                refreshData();
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewX1.SelectedRows[0];
                    string maHangHoa = row.Cells["MASP"].Value.ToString().Trim();
                    if (dal_hanghoa.xoaHangHoa(maHangHoa) == 1)
                    {
                        MessageBox.Show("Đã ẩn hàng hóa thành công !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dsHangHoa = dal.getHangHoa("");
                        taiGridViewHangHoa();
                    }
                    else
                    {
                        MessageBox.Show("Vẫn còn hàng hóa trong kho !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Xóa hàng hóa thất bại !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSuaMatHang_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewX1.SelectedRows[0];
                Program.frmSuaHangHoa = new frmSuaHangHoa(row.Cells["MASP"].Value.ToString().Trim());
                DialogResult rs = Program.frmSuaHangHoa.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    refreshData();
                }
            }
        }

        private void btnThemHangVaoKho_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewX1.SelectedRows[0];
                Program.frmNhapHangHoaVaoKho = new frmNhapHangHoaVaoKho(row.Cells["MASP"].Value.ToString().Trim());
                DialogResult rs = Program.frmNhapHangHoaVaoKho.ShowDialog();
                if (rs == DialogResult.OK)
                    refreshData();
            }
        }

        public void refreshData()
        {
            danhMucHangHoa = dal.getDanhMuc();
            dsHangHoa = dal.getHangHoa("");
            taiTreeViewNhomMatHang();
            taiGridViewHangHoa();
            Program.frmHoaDon.taiTreeView();
            Program.frmHoaDon.taiGridViewHangHoa();
        }

    }
}
