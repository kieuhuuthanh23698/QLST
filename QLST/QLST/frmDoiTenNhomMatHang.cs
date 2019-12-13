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
    public partial class  frmDoiTenNhomMatHang : Form
    {
        DAL_HangHoa dal = new DAL_HangHoa();
        string ten;
        public static string tenConfig;

        public frmDoiTenNhomMatHang(string ten)
        {
            InitializeComponent();
            this.ten = ten;
            txtTenNhomMatHang.Text = ten;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenNhomMatHang.Text.Equals(ten) == false)
                {
                    dal.doiTenLoaiHangHoa(ten, txtTenNhomMatHang.Text);
                    MessageBox.Show("Sửa thành công !", "Sửa tên nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tenConfig = txtTenNhomMatHang.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
