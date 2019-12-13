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
    public partial class frmThemSanPham : Form
    {
        DAL_HoaDon dal = new DAL_HoaDon();
        DAL_HangHoa dalhh = new DAL_HangHoa();

        public frmThemSanPham()
        {
            InitializeComponent();
            taiComBBNhomMathang();
        }

        public void taiComBBNhomMathang()
        {
            try
            {
                cbbNhomMatHang.DataSource = dal.getDanhMuc();
                cbbNhomMatHang.DisplayMember = "TENLOAI";
                cbbNhomMatHang.ValueMember = "MALOAI";
                cbbNhomMatHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbNhomMatHang_SelectedValueChanged(object sender, EventArgs e)
        {
            txtMa.Text = dalhh.taoMaHangHoa(cbbNhomMatHang.SelectedValue.ToString().Trim());
        }

        private void txtGiamua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text != "" && txtDonvi.Text != "" && txtGiaban.Text != "")
            {
                try
                {
                    dalhh.themHangHoa(cbbNhomMatHang.SelectedValue.ToString(), txtMa.Text, txtTen.Text, txtDonvi.Text, txtGiaban.Text);
                    MessageBox.Show("Thêm hàng hóa thành công !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm hàng hóa thất bại !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                if (txtTen.Text == "")
                    MessageBox.Show("Bạn chưa nhập tên hàng hóa !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtDonvi.Text == "")
                    MessageBox.Show("Bạn chưa nhập đơn vị của hàng hóa !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtGiaban.Text == "")
                    MessageBox.Show("Bạn chưa nhập giá bán !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
