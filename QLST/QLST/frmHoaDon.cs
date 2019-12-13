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
    public partial class frmHoaDon : Form
    {
        DAL_HoaDon dalHoaDon = new DAL_HoaDon();
        List<DANH_MUC_SP> danhMucHangHoa;
        List<HANGHOA> dsHangHoa;

        public frmHoaDon()
        {
            InitializeComponent();
            danhMucHangHoa = dalHoaDon.getDanhMuc();
            dsHangHoa = dalHoaDon.getHangHoa("");
            taiGridViewHangHoa();
            taiTreeView();
            taiAutoCompleteText();
            cmbTienKhachDua.SelectedIndex = 0;
            ImageList im = new ImageList();
            im.Images.Add(QLST.Properties.Resources.father_node);
            im.Images.Add(QLST.Properties.Resources.child_node);
            treeView1.ImageList = im;
        }

        public void reFreshData() {
            dsHangHoa = dalHoaDon.getHangHoa("");
            danhMucHangHoa = dalHoaDon.getDanhMuc();
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
         
        public void taiAutoCompleteText()
        {
            try
            {
                foreach (var item in dsHangHoa)
                {
                    autoCompleteTextTenHangHoa.AutoCompleteCustomSource.Add(item.TENSP.Trim());
                    autoCompleteTextTenHangHoa.AutoCompleteCustomSource.Add(item.MASP.Trim());
                }
                foreach (var item in danhMucHangHoa)
                {
                    autoCompleteTextTenHangHoa.AutoCompleteCustomSource.Add(item.MALOAI.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private void autoCompleteTextTenHangHoa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (autoCompleteTextTenHangHoa.Text.Trim().Equals("") == true)
                {
                    reFreshData();
                }
                else
                {
                    dsHangHoa = dalHoaDon.getHangHoa(autoCompleteTextTenHangHoa.Text.Trim());
                }
                taiGridViewHangHoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    string giaBan = dataGridViewHangHoa.Rows[i].Cells["GIA_BAN_1"].Value.ToString();
                    int viTri = timViTriMonHangTrongGio(tenHangHoa);
                    int soLuongHangHoaTrongGio = hangHoaNayCoTrongGioChua(tenHangHoa);
                    int soluong = (int)Int64.Parse(numericThem.Value.ToString()) + soLuongHangHoaTrongGio;
                    double thanhTien = soluong * Double.Parse(giaBan);

                    if (soLuongHangHoaTrongGio == 0)
                    {
                        ListViewItem item = new ListViewItem(stt + "");
                        string[] subItem = { tenHangHoa, giaBan, soluong + "", thanhTien + "", masp};
                        item.SubItems.AddRange(subItem);
                        lstGioHang.Items.Add(item);
                    }
                    else
                    {
                        lstGioHang.Items[viTri].SubItems[3].Text = soluong + "";
                        lstGioHang.Items[viTri].SubItems[4].Text = soluong * Double.Parse(giaBan) + "";
                    }
                    numericThem.Value = 1;
                    tinhTien();
                }
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
                    string giaBan = dataGridViewHangHoa.Rows[i].Cells["GIA_BAN_1"].Value.ToString();
                    int viTri = timViTriMonHangTrongGio(tenHangHoa);
                    int timKiem = hangHoaNayCoTrongGioChua(tenHangHoa);
                    int soluong = 1 + timKiem;
                    double thanhTien = soluong * Double.Parse(giaBan);

                    if (soluong == 1)
                    {
                        ListViewItem item = new ListViewItem(stt + "");
                        string[] subItem = { tenHangHoa, giaBan, soluong + "", thanhTien + "", masp};
                        item.SubItems.AddRange(subItem);
                        lstGioHang.Items.Add(item);
                    }
                    else
                    {
                        lstGioHang.Items[viTri].SubItems[3].Text = soluong + "";
                        lstGioHang.Items[viTri].SubItems[4].Text = soluong * Double.Parse(giaBan) + "";
                    }
                    tinhTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        public void tinhTien()
        {
            try
            {
                //tính thành tiền
                double thanhTien = 0;
                foreach (ListViewItem item in lstGioHang.Items)
                    thanhTien += Double.Parse(item.SubItems[4].Text);
                txtTienHang.Text = thanhTien + "";
                txtTichDiem.Text = ((int)thanhTien * 0.005).ToString();
                //giảm giá
                //if (txtDungDiemTichLuy.Text != "")
                //{
                //    int phantram = (int)Int64.Parse(txtDungDiemTichLuy.Text);
                //    txtDungDiemTichLuy.Text = Double.Parse(txtTienHang.Text) * phantram * 0.01 + "";
                //}
                txtTongGiaTriGioHang.Text = (Double.Parse(txtTienHang.Text) - Double.Parse(txtDungDiemTichLuy.Text)) + "";
                if (cmbTienKhachDua.Text != "")
                {
                    txtTienTraLai.Text = (Int64.Parse(cmbTienKhachDua.Text) - Double.Parse(txtTongGiaTriGioHang.Text)) + "";
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
                    return (int)Int64.Parse(lstGioHang.Items[i].SubItems[3].Text.ToString());
                }
            }
            return 0;
        }
         
        public string timTenNhanVien()
        {
            try
            {
                DAL_Main dal = new DAL_Main();
                return dal.getNameNV(frmLogin.nhanVien.MANV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
         
        public string taoMaHoaDon()
        {
            try
            {
                return dalHoaDon.taoMaHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
         
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                taoHoaDonMoi();
                loadComBoBoxKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        public void loadComBoBoxKhachHang()
        {
            try
            {
                cbbKhachHang.DataSource = dalHoaDon.getKhachHang();
                cbbKhachHang.DisplayMember = "TENKH";
                cbbKhachHang.ValueMember = "MAKH";
                cbbKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private void cmbTienKhachDua_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhTien();
        }
         
        private void txtPhanTramGiamGia_TextChanged(object sender, EventArgs e)
        {
            tinhTien();
        }
         
        private void cmbTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            tinhTien();
        }
         
        private void cmbTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }
         
        private void btnXoaHangTrongGio_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem i in lstGioHang.SelectedItems)
                {
                    lstGioHang.Items.Remove(i);
                }
                tinhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private void btnTangSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                if (lstGioHang.SelectedItems.Count != 0)
                {
                    i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                    lstGioHang.Items[i].SubItems[3].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) + int.Parse(numericTang.Value.ToString())) + "";
                    lstGioHang.Items[i].SubItems[4].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) * Double.Parse(lstGioHang.Items[i].SubItems[2].Text)) + "";
                    tinhTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private void btnGiamSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                if (lstGioHang.SelectedItems.Count != 0)
                {
                    i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                    if (int.Parse(numericGiam.Value.ToString()) >= int.Parse(lstGioHang.Items[i].SubItems[3].Text))
                    {
                        lstGioHang.Items.Remove(lstGioHang.Items[i]);
                    }
                    else
                    {
                        lstGioHang.Items[i].SubItems[3].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) - int.Parse(numericGiam.Value.ToString())) + "";
                        lstGioHang.Items[i].SubItems[4].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) * Double.Parse(lstGioHang.Items[i].SubItems[2].Text)) + "";
                    }
                    numericGiam.Value = 1;
                    tinhTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // chỉ thanh toán khi :
            //  số tiền trả lại(số tiền khách đưa - tiền hàng) >= 0 
            //  trong giỏ có hàng
            //  tất cả các thông tin cần thiết đều có
            //  sau khi insert hóa đơn
            // insert từng chi tiết hóa đơn 
            // update điểm tích lũy
            try
            {
                if (lstGioHang.Items.Count > 0)
                {

                    if (cmbTienKhachDua.Text != "")
                    {
                        if (Double.Parse(txtTienTraLai.Text) >= 0)
                        {
                            try
                            {
                                dalHoaDon.thanhToanHoaDon(txtMaHoaDon.Text, frmLogin.nhanVien.MANV, cbbKhachHang.SelectedValue.ToString(), txtTongGiaTriGioHang.Text, txtDungDiemTichLuy.Text,txtTichDiem.Text ,convertGioHang(lstGioHang));
                                rptHoaDonBanHang rpt = new rptHoaDonBanHang();
                                contentReportHoaDon content = new contentReportHoaDon();
                                content.mahd = txtMaHoaDon.Text;
                                content.tenkh = cbbKhachHang.Text;
                                content.tennv = txtNhanVien.Text;
                                content.tongThanhTien = txtTongGiaTriGioHang.Text;
                                content.tienHang = txtTienHang.Text;
                                content.tichDiem = txtTichDiem.Text;
                                content.dungDiem = txtDungDiemTichLuy.Value.ToString();
                                content.khachDua = cmbTienKhachDua.Text;
                                content.traLai = txtTienTraLai.Text;
                                content.diemTichLuyHientai = (int.Parse(dalHoaDon.getTichLuy(cbbKhachHang.SelectedValue.ToString())) + (int.Parse(txtTichDiem.Text) - int.Parse(txtDungDiemTichLuy.Value.ToString()))).ToString();
                                content.dataSource = convertGioHang(lstGioHang);
                                string path = txtMaHoaDon.Text;
                                rpt.ExporHoaDon(content, ref path, false);
                                if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(path);
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString());
                            }
                            dsHangHoa = dalHoaDon.getHangHoa("");
                            dataGridViewHangHoa.DataSource = dsHangHoa;
                            taoHoaDonMoi();
                        }
                        else
                            MessageBox.Show("Khách chưa đưa đủ tiền !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("Khách chưa đưa tiền !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Hãy chọn hàng trước khi thanh toán !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private List<CHITIET_HD> convertGioHang(ListView lstGioHang) {
            List<CHITIET_HD> res = new List<CHITIET_HD>();
            foreach (ListViewItem item in lstGioHang.Items)
            {
                CHITIET_HD CTHD = new CHITIET_HD();
                CTHD.MAHD = txtMaHoaDon.Text;
                CTHD.MASP = item.SubItems[5].Text;
                CTHD.TENHH = item.SubItems[1].Text.Trim();
                CTHD.GIABAN = item.SubItems[2].Text.Trim();
                CTHD.SL_MUA = int.Parse(item.SubItems[3].Text.Trim());
                CTHD.THANHTIEN = item.SubItems[4].Text.Trim();
                res.Add(CTHD);
            }
            return res;
        }
         
        public void taoHoaDonMoi()
        {
            try
            {
                taiGridViewHangHoa();
                txtMaHoaDon.Text = taoMaHoaDon();
                txtNhanVien.Text = timTenNhanVien();
                dateTimeInput1.Value = DateTime.Now;
                txtGio.Text = dateTimeInput1.Value.ToShortTimeString();
                lstGioHang.Items.Clear();
                txtTienHang.Text = "0";
                txtDungDiemTichLuy.Text = "0";
                txtTichDiem.Text = "0";
                txtTongGiaTriGioHang.Text = "0";
                txtTienTraLai.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
         
        private void cbbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbbKhachHang.SelectedValue.ToString().Equals("KH1"))
            {
                string dtl = dalHoaDon.getTichLuy(cbbKhachHang.SelectedValue.ToString());
                if (dtl != "")
                {
                    lblMaxDiem.Text = "/ " + dtl;
                    txtDungDiemTichLuy.Maximum = int.Parse(dtl);
                    txtDungDiemTichLuy.Minimum = 0;
                }
            }
        }
    }

}
