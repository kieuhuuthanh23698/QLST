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
    public partial class frmLogin : Form
    {
        DAL_Login dal_login = new DAL_Login();
        public static TAI_KHOAN nhanVien = null;  

        public frmLogin()
        {
            InitializeComponent();
            txtTenDangNhap.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {   
            if (txtTenDangNhap.Text == "")
            {
                this.errorProvider1.SetError(txtTenDangNhap, "Bạn không được để trống tên đăng nhập !");
                txtMatKhau.Focus();
                return;
            }
            else
                this.errorProvider1.Clear();


            if (txtMatKhau.Text == "")
            {
                this.errorProvider1.SetError(txtMatKhau, "Bạn không được để trống mật khẩu !");
                txtMatKhau.Focus();
                return;
            }
            else
                this.errorProvider1.Clear();


            int kq = dal_login.checkConfig();
            switch (kq)
            {
                case 0:
                    ProccessLogin();
                    break;
                case 1:
                    MessageBox.Show("Chuỗi cấu hình không tồn tại !");
                    ProcessConfig();
                    break;
                case 2:
                    MessageBox.Show("Chuỗi cấu hình không hợp lệ !");
                    ProcessConfig();
                    break;
            }

        }

        private void ProcessConfig()
        {
            if (Program.frmCauHinh == null || Program.frmCauHinh.IsDisposed)
            {
                Program.frmCauHinh = new frmKetNoi();
            }
            this.Visible = false;
            Program.frmCauHinh.Show();
        }

        private void ProccessLogin()
        {
            LoginResult res = dal_login.checkUser(txtTenDangNhap.Text, txtMatKhau.Text);
            if (res == LoginResult.Invalid)
            {
                MessageBox.Show("Sai mật khẩu hoặc password !");
                return;
            }
            if (res == LoginResult.Invalid)
            {
                MessageBox.Show("Tài khoảng bị khóa !");
                return;
            }
            if (res == LoginResult.Success)
            {
                nhanVien = dal_login.getTaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text);
                if (Program.frmMain == null || Program.frmMain.IsDisposed)
                    Program.frmMain = new frmMain();
                this.Visible = false;
                Program.frmMain.Show();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit(); 
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
                this.errorProvider1.SetError(txtTenDangNhap, "Bạn không được để trống tên đăng nhập !");
            else
                this.errorProvider1.Clear();
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
                this.errorProvider1.SetError(txtMatKhau, "Bạn không được để trống mật khẩu !");
            else
                this.errorProvider1.Clear();
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control trl = (Control)sender;
            if (txtTenDangNhap.Text.Length > 30)
                this.errorProvider1.SetError(trl, "Tên đăng nhập không quá 30 ký tự !");
            else
                this.errorProvider1.Clear();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control trl = (Control)sender;
            if (txtMatKhau.Text.Length > 30)
                this.errorProvider1.SetError(trl, "Mật khẩu không quá 30 ký tự !");
            else
                this.errorProvider1.Clear();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
