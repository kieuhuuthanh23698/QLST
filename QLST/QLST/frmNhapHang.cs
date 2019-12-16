using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace QLST
{
    public partial class frmNhapHang : Form
    {
        dalNhapHang dal = new dalNhapHang();
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.MAPN = txtMaPhieu.Text.Trim();
            pn.MADDH = (cbb_dondathang.Items.Count == 0 ? null : cbb_dondathang.SelectedValue.ToString());
            pn.NGAYLAP_PN = datePN.Value;
            if (dal.ThemPhieuNhap(pn))
            {
                MessageBox.Show("Bạn đã thêm phiếu nhập " + txtMaPhieu.Text);
                panelSP.Enabled = true;
                panelPN.Enabled = false;
            }
            else { MessageBox.Show("Thêm thất bại"); }
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            txtMaPhieu.Text = dal.TaoMaPhieuNhap();
            cbb_dondathang.DataSource = dal.getdondathang();
            cbb_dondathang.DisplayMember = "MADDH";
            cbb_dondathang.ValueMember = "MADDH";
        }

        private void cboSP_DropDown(object sender, EventArgs e)
        {
            cboSP.DataSource = dal.LoadCboSP();
            cboSP.DisplayMember = "TENSP";
            cboSP.ValueMember = "MASP";
            cboSP.SelectedIndex = 0;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboSP.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm");
                cboSP.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá");
                txtDonGia.Focus();
                return;
            }
            if (dateHSD.Value < dateNSX.Value)
            {
                MessageBox.Show("Hạn dùng phải lớn hơn ngày sản xuất");
                dateHSD.Focus();
                return;
            }
            else
            {
                LO_HANG lh = new LO_HANG();
                lh.MAPN = txtMaPhieu.Text.Trim();
                lh.MASP = cboSP.SelectedValue.ToString();
                lh.NGAYSX = dateNSX.Value;
                lh.HANSD = dateHSD.Value;
                lh.SOLUONGNHAP = int.Parse(txtSoLuong.Text.Trim());
                lh.SOLUONG_TRENQUAY = 0;
                lh.DONGIA_NHAP = float.Parse(txtDonGia.Text.Trim());
                if (dal.ThemSPvaoLoHang(lh))
                {
                    dataGVSP.DataSource = dal.LoadLoHang(lh.MAPN);
                    int sl = (int)lh.SOLUONGNHAP;
                    float dg = (float)lh.DONGIA_NHAP;
                    double tt =  sl*dg;
                    dal.UpdateTongTien(lh.MAPN, tt);
                    txtTongTien.Text = dal.TongTien(lh.MAPN);
                }
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                int index = dataGVSP.CurrentCell.RowIndex;
                string masp = dataGVSP.Rows[index].Cells["MASP"].Value.ToString().Trim();
                string mapn = dataGVSP.Rows[index].Cells["MAPN"].Value.ToString().Trim();
                int sl = int.Parse(dataGVSP.Rows[index].Cells["SOLUONGNHAP"].Value.ToString().Trim());
                float dg = float.Parse(dataGVSP.Rows[index].Cells["DONGIA_NHAP"].Value.ToString().Trim());
                double tt = sl*dg;
                if (dal.XoaSp(masp,mapn,tt))
                {
                    dataGVSP.DataSource =  dal.LoadLoHang(mapn);
                    txtTongTien.Text = dal.TongTien(mapn);
                    MessageBox.Show("Xóa thành công");
                }
                else { MessageBox.Show("Xóa thất bại"); }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
                return;
            }
        }
    }
}
