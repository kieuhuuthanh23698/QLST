using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DAL;

namespace QLST
{
    public partial class frmKetNoi : Form
    {
        DAL_CauHinh dalCauHinh = new DAL_CauHinh();
        DAL_Login dalLogin = new DAL_Login();

        public frmKetNoi()
        {
            InitializeComponent();
            DataTable tb = dalCauHinh.getServerName();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    string SQLServer = r["ServerName"].ToString();
                    string Instance = r["InstanceName"].ToString();
                    if (Instance != null && !string.IsNullOrEmpty(Instance))
                    {
                        cbbDataSource.Items.Add(SQLServer + "\\" + Instance);
                    }
                    else
                        cbbDataSource.Items.Add(SQLServer);
                }
                cbbDataSource.SelectedIndex = 0;
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (cbbDataSource.Text != "" && txtID.Text != "" && cbbIni.Text != "" && txtPass.Text != "")
            {
               this.errorProvider1.Clear();
               dalCauHinh.saveConfig(cbbDataSource.Text, cbbIni.Text, txtID.Text, txtPass.Text);
                Properties.Settings.Default["QLSTConnectionString"] = @"Data Source=" + cbbDataSource.Text + ";Initial Catalog=" + cbbIni.Text + "; User ID=" + txtID.Text + ";password=" + txtPass.Text;
                Properties.Settings.Default.Save();
                if (dalLogin.checkConfig() == 0)
                {
                    frmLogin frmlogin = new frmLogin();
                    this.Hide();
                    frmlogin.Show();
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại !", "CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cbbDataSource.Text == "")
                    this.errorProvider1.SetError(cbbDataSource, "Bạn không được để trống tên server của database !");
                if (txtID.Text == "")
                    this.errorProvider1.SetError(txtID, "Không được để trống !");
                if (cbbIni.Text == "")
                    this.errorProvider1.SetError(cbbIni, "Không được để trống username đăng nhập vào server !");
                if (txtPass.Text == "")
                    this.errorProvider1.SetError(txtPass, "Không được để trống mật khẩu đăng nhập vào server !");
            }
            }

        private void txtDataSource_Leave(object sender, EventArgs e)
        {
            if (cbbDataSource.Text == "")
                this.errorProvider1.SetError(cbbDataSource, "Bạn không được để trống tên server của database !");
            else
                this.errorProvider1.Clear();
        }

        private void txtIni_Leave(object sender, EventArgs e)
        {
            if (cbbIni.Text == "")
                this.errorProvider1.SetError(cbbIni, "Không được để trống tên database !");
            else
                this.errorProvider1.Clear();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                this.errorProvider1.SetError(txtID, "Không được để trống username đăng nhập vào server !");
            else
                this.errorProvider1.Clear();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
                this.errorProvider1.SetError(txtPass, "Không được để trống mật khẩu đăng nhập vào server !");
            else
                this.errorProvider1.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbbIni_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = dalCauHinh.getDatabaseName(cbbDataSource.Text, txtID.Text, txtPass.Text);
                if (tb != null)
                {
                    cbbIni.DataSource = tb;
                    cbbIni.DisplayMember = "name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
