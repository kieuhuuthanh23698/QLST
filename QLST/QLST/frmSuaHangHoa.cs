using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;

namespace QLST
{
    public partial class frmSuaHangHoa : Form
    {
        DAL_HoaDon dal = new DAL_HoaDon();
        DAL_HangHoa dal1 = new DAL_HangHoa();
        string mahh;

        public frmSuaHangHoa(string mahh)
        {
            try
            {
                InitializeComponent();
                this.mahh = mahh;
                HANGHOA sp = dal.getHangHoa(mahh)[0];
                txtTen.Text = sp.TENSP;
                txtDonvi.Text = sp.DVT;
                txtGiaban.Text = sp.GIA_BAN.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text != "" && txtGiaban.Text != "" && txtDonvi.Text != "")
            {
                try {
                    string res = dal1.updateHH(mahh, txtTen.Text, txtDonvi.Text, txtGiaban.Text);
                    MessageBox.Show(res, "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),"EXCEPTION",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show("Sửa thông tin hàng hóa thất bại !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if(txtTen.Text == "")
                    MessageBox.Show("Bạn chưa nhập tên hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if(txtDonvi.Text == "")
                    MessageBox.Show("Bạn chưa nhập đơn vị hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtGiaban.Text == "")
                    MessageBox.Show("Bạn chưa nhập giá bán của hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


    
    
