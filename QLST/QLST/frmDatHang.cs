using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace QLST
{
    public partial class frmDatHang : Form
    {
        DAL_HoaDon dalHoaDon = new DAL_HoaDon();
        DAL_NhaCungCap nhacungcap = new DAL_NhaCungCap();
        List<DANH_MUC_SP> danhMucHangHoa;
        List<HANGHOA> dsHangHoa;
        public frmDatHang()
        {
            InitializeComponent();
        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            danhMucHangHoa = dalHoaDon.getDanhMuc();
            dsHangHoa = dalHoaDon.getHangHoa("");
            taiGridViewHangHoa();
            taiTreeView();
            ImageList im = new ImageList();
            im.Images.Add(QLST.Properties.Resources.father_node);
            im.Images.Add(QLST.Properties.Resources.child_node);
            treeView1.ImageList = im;
            loadcombobox();
            TaoDonHangMoi();


            btnXoaHangTrongGio.Click += btnXoaHangTrongGio_Click;
            btnTangSoLuong.Click += btnTangSoLuong_Click;
            btnGiamSoLuong.Click += btnGiamSoLuong_Click;
            btnThanhToan.Click += btnThanhToan_Click;
        }

        void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lstGioHang.Items.Count > 0)
            {
                if (dalHoaDon.TaoDonHang(txtMaHoaDon.Text, cbbNhaCungCap.SelectedValue.ToString(), dtp_ngaylap.Value, txtGhiChu.Text, convertDonHang(lstGioHang)))
                {
                    MessageBox.Show("Tạo đơn đặt hàng thành công!", "THÔNG BÁO");
                    lstGioHang.Items.Clear();
                    TaoDonHangMoi();
                }
                else
                {
                    MessageBox.Show("Tạo đơn đặt hàng thất bại!", "THÔNG BÁO");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập sản phẩm vào trước khi tạo!", "THÔNG BÁO");
            }
        }
        private void loadcombobox()
        {
            cbbNhaCungCap.DataSource = nhacungcap.getNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TEN_NCC";
            cbbNhaCungCap.ValueMember = "MANCC";
        }
        private void TaoDonHangMoi()
        {
            txtMaHoaDon.Text = "DDH" + dalHoaDon.getMaxIDDonDatHang();
        }
        void btnGiamSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                if (lstGioHang.SelectedItems.Count != 0)
                {
                    i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                    if (int.Parse(numericGiam.Value.ToString()) >= int.Parse(lstGioHang.Items[i].SubItems[2].Text))
                    {
                        lstGioHang.Items.Remove(lstGioHang.Items[i]);
                    }
                    else
                    {
                        lstGioHang.Items[i].SubItems[2].Text = (int.Parse(lstGioHang.Items[i].SubItems[2].Text) - int.Parse(numericGiam.Value.ToString())) + "";
                    }
                    numericGiam.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void btnTangSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                if (lstGioHang.SelectedItems.Count != 0)
                {
                    i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                    lstGioHang.Items[i].SubItems[2].Text = (int.Parse(lstGioHang.Items[i].SubItems[2].Text) + int.Parse(numericTang.Value.ToString())) + "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void btnXoaHangTrongGio_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem i in lstGioHang.SelectedItems)
                {
                    lstGioHang.Items.Remove(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void taiTreeView()
        {
            try
            {
                int i = 0;
                treeView1.Nodes[0].Nodes.Clear();
                foreach (var item in danhMucHangHoa)
                {
                    treeView1.Nodes[0].Nodes.Add(item.TENLOAI);
                    treeView1.Nodes[0].Nodes[i++].ImageIndex = 1;
                }
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void taiGridViewHangHoa()
        {
            try
            {
                dataGridViewHangHoa.DataSource = dsHangHoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void reFreshData()
        {
            dsHangHoa = dalHoaDon.getHangHoa("");
            danhMucHangHoa = dalHoaDon.getDanhMuc();
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                {
                    reFreshData();
                }
                else
                {
                    dsHangHoa = dalHoaDon.getHangHoa(e.Node.Text.Trim());
                }
                taiGridViewHangHoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridViewHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                if (i > -1)
                {
                    int stt = lstGioHang.Items.Count;
                    string masp = dataGridViewHangHoa.Rows[i].Cells["MaHangHoa"].Value.ToString();
                    string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["TenHangHoa"].Value.ToString();
                    int viTri = timViTriMonHangTrongGio(tenHangHoa);
                    int timKiem = hangHoaNayCoTrongGioChua(tenHangHoa);
                    int soluong = 1 + timKiem;

                    if (soluong == 1)
                    {
                        ListViewItem item = new ListViewItem(stt + "");
                        string[] subItem = { tenHangHoa, soluong + "" , masp };
                        item.SubItems.AddRange(subItem);
                        lstGioHang.Items.Add(item);
                    }
                    else
                    {
                        lstGioHang.Items[viTri].SubItems[2].Text = soluong + "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int timViTriMonHangTrongGio(string tenHang)
        {
            foreach (ListViewItem item in lstGioHang.Items)
                if (item.SubItems[1].Text.Equals(tenHang) == true)
                    return item.Index;
            return -1;
        }

        public int hangHoaNayCoTrongGioChua(string tenHang)
        {
            int n = lstGioHang.Items.Count;
            for (int i = 0; i < n; i++)
            {
                if (lstGioHang.Items[i].SubItems[1].Text.Equals(tenHang) == true)
                {
                    return (int)Int64.Parse(lstGioHang.Items[i].SubItems[2].Text.ToString());
                }
            }
            return 0;
        }

        private void btnThemHangHoaVaoGio_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridViewHangHoa.CurrentCell.RowIndex;
                if (i > -1)
                {
                    int stt = lstGioHang.Items.Count;
                    string masp = dataGridViewHangHoa.Rows[i].Cells["MaHangHoa"].Value.ToString();
                    string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["TenHangHoa"].Value.ToString();
                    int viTri = timViTriMonHangTrongGio(tenHangHoa);
                    int soLuongHangHoaTrongGio = hangHoaNayCoTrongGioChua(tenHangHoa);
                    int soluong = (int)Int64.Parse(numericThem.Value.ToString()) + soLuongHangHoaTrongGio;

                    if (soLuongHangHoaTrongGio == 0)
                    {
                        ListViewItem item = new ListViewItem(stt + "");
                        string[] subItem = { tenHangHoa,soluong + "",  masp };
                        item.SubItems.AddRange(subItem);
                        lstGioHang.Items.Add(item);
                    }
                    else
                    {
                        lstGioHang.Items[viTri].SubItems[2].Text = soluong + "";
                    }
                    numericThem.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<CHI_TIET_DDH> convertDonHang(ListView lstGioHang)
        {
            List<CHI_TIET_DDH> res = new List<CHI_TIET_DDH>();
            foreach (ListViewItem item in lstGioHang.Items)
            {
                CHI_TIET_DDH ct = new CHI_TIET_DDH();
                ct.MADDH = txtMaHoaDon.Text;
                ct.MASP = item.SubItems[3].Text.Trim();
                ct.SOLUONGDAT = int.Parse(item.SubItems[2].Text.Trim());
                res.Add(ct);
            }
            return res;
        }

    }
}
