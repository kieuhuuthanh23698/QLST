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
    public partial class frmDanhMucKhachHang : Form
    {
        DAL_KhachHang dal = new DAL_KhachHang();
        List<KHACH_HANG> lstKH;

        public frmDanhMucKhachHang()
        {
            InitializeComponent();
            lstKH = dal.getKhachHang();
            TaiGridViewKhachHang();
            loadAutoCompleteTextTimKiemNhanVien();
            btnHuyThem.Hide();
        }

        public void loadAutoCompleteTextTimKiemNhanVien()
        {
            try
            {
                foreach (KHACH_HANG item in lstKH)
                {
                    txtTimKiem.AutoCompleteCustomSource.Add(item.TENKH.ToString().Trim());
                    txtTimKiem.AutoCompleteCustomSource.Add(item.SDT.ToString().Trim());
                    txtTimKiem.AutoCompleteCustomSource.Add(item.EMAIL.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void TaiGridViewKhachHang()
        {
            try
            {
                dataGridViewKhachHang.DataSource = lstKH;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMa.Text = dal.taoMaKH();
            txtSDT.Text = txtTen.Text = "";
            txtTen.Focus();

            btnLuu.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnChinhsua.Enabled = dataGridViewKhachHang.Enabled = false;

            btnHuyThem.Show();
        }

        private void btnChinhsua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "" && txtEmail.Text != "" && txtSDT.Text != "")
                {
                    dal.themKH(txtMa.Text,txtTen.Text, txtDiaChi.Text, txtSDT.Text,txtEmail.Text);
                    MessageBox.Show("Thêm thành công !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstKH = dal.getKhachHang();
                    TaiGridViewKhachHang();
                    btnXoa.Enabled = btnChinhsua.Enabled = btnThem.Enabled = dataGridViewKhachHang.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuyThem.Hide();
                    txtMa.Text = txtSDT.Text = txtTen.Text = txtDiaChi.Text = txtEmail.Text = "";
                }
                else
                {
                    if (txtTen.Text == "")
                        MessageBox.Show("Bạn chưa nhập tên khách hàng !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txtSDT.Text == "")
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnChinhsua.Enabled = true;
            dataGridViewKhachHang.Enabled = true;
            txtMa.Text = txtSDT.Text = txtTen.Text = txtDiaChi.Text = txtEmail.Text = txtSDT.Text = "";
            btnHuyThem.Hide();
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow item_row = dataGridViewKhachHang.SelectedRows[0];
                txtMa.Text = item_row.Cells["MAKH"].Value.ToString().Trim();
                txtTen.Text = item_row.Cells["TENKH"].Value.ToString().Trim();
                txtSDT.Text = item_row.Cells["SDT"].Value.ToString().Trim();
                txtDiaChi.Text = item_row.Cells["DIACHI"].Value.ToString().Trim();
                txtEmail.Text = item_row.Cells["EMAIL"].Value.ToString().Trim();
                txtTichLuy.Text = item_row.Cells["TICHLUY"].Value.ToString().Trim();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtTimKiem.Text == "")
            //        TaiGridViewKhachHang();
            //    else
            //        dataGridViewKhachHang.DataSource = this.kn.comManTable("select * from KhachHang where MaKhachHang = '" + txtTimKiem.Text + "' or TenKhachHang = N'" + txtTimKiem.Text + "' or SoDienThoai = '" + txtTimKiem.Text + "'", "KhachHang").Tables["KhachHang"];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
