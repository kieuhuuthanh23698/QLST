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
    public partial class frmThemNhomMatHang : Form
    {
        DAL_HangHoa dal = new DAL_HangHoa();

        public frmThemNhomMatHang()
        {
            InitializeComponent();
            txtMaNhomMatHang.Text = dal.taoMaLoaiHH();
        }

        private void btnThemNhomMatHang_Click(object sender, EventArgs e)
        {   try
            {
                if (txtMaNhomMatHang.Text != "" && txtTenNhomMatHang.Text != "")
                {
                    dal.themLoaiHH(txtMaNhomMatHang.Text, txtTenNhomMatHang.Text);
                    MessageBox.Show("Thêm thành công !", "Thêm nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    txtTenNhomMatHang.Text = "";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTenNhomMatHang_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNhomMatHang.Text.Length > 50)
            {
                balloonTip1.SetBalloonText(txtTenNhomMatHang, "Tên nhóm mặt hàng không được dài quá 50 kí tự");
                balloonTip1.ShowBalloon(txtTenNhomMatHang);
            }
            else
                balloonTip1.RemoveAll();

        }

        private void txtTenNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTenNhomMatHang.Text.Length > 50 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtMaNhomMatHang_TextChanged(object sender, EventArgs e)
        {
            //kiểm tra độ dài tên nhóm mặt hàng, nếu quá 20 kí tự thì ko cho nhập, đồng thời báo lỗi qua error provider
            if (txtMaNhomMatHang.Text.Length > 20)
            {
                balloonTip1.SetBalloonText(txtMaNhomMatHang, "Mã nhóm mặt hàng không được quá 20 kí tự");
                balloonTip1.ShowBalloon(txtMaNhomMatHang);
            }
            else
                balloonTip1.RemoveAll(); ;
        }

        private void txtMaNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaNhomMatHang.Text.Length > 20 && e.KeyChar != '\b')
                e.Handled = true;
        }

    }
}
