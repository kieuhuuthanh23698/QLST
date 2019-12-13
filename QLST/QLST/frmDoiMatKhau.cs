using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace QLST
{
    public partial class frmDoiMatKhau : Form
    {
        DAL_Login dal = new DAL_Login();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauCu.Text != "" && txtMatKhauMoi.Text != "" && txtMatKhauMoiNhapLai.Text != "")
                {
                    if (txtMatKhauMoi.Text == txtMatKhauMoiNhapLai.Text)
                    {
                        if (!txtMatKhauCu.Text.Equals(frmLogin.nhanVien.MATKHAU))
                        {
                            bool kqUpdate = dal.changePassword(frmLogin.nhanVien.TENDN, txtMatKhauMoi.Text);
                            if (kqUpdate)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công !");
                                this.Close();
                            }
                            else
                                MessageBox.Show("Đổi mật khẩu thất bại !");
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cũ nhập sai !");
                            txtMatKhauCu.Text = "";
                            txtMatKhauCu.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và nhập lại không giống nhau !");
                        txtMatKhauMoi.Text = "";
                        txtMatKhauMoiNhapLai.Text = "";
                        txtMatKhauMoi.Focus();
                    }
                }
                else
                {
                    if (txtMatKhauCu.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu cũ !");
                    }
                    if (txtMatKhauMoi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới !");
                    }
                    if (txtMatKhauMoiNhapLai.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới nhập lại !");
                    }
                    txtMatKhauCu.Text = "";
                    txtMatKhauMoi.Text = "";
                    txtMatKhauMoiNhapLai.Text = "";
                    txtMatKhauCu.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}
