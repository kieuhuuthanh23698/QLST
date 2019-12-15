using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace QLST
{
    public partial class frmDanhMucNhaCungCap : Form
    {
        public frmDanhMucNhaCungCap()
        {
            InitializeComponent();
        }

        DAL_NhaCungCap nhacungcap = new DAL_NhaCungCap();
        bool flag = false;
        private void frmDanhMucNhaCungCap_Load(object sender, EventArgs e)
        {
            dataGridView_NCC.DataSource = nhacungcap.getNhaCungCap();
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            string mancc = txtMa.Text.ToString().Trim();
            string ten = txtTen.Text.ToString().Trim();
            string diachi = txtDiachi.Text.ToString().Trim();
            string email = txtMail.Text.ToString().Trim();
            string sdt = txtSDT.Text.ToString().Trim();
            if (nhacungcap.ThemNhaCungCap(mancc, ten, diachi, email, sdt))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "THÔNG BÁO");
                dataGridView_NCC.DataSource = nhacungcap.getNhaCungCap();
                btnLuu.Enabled = false;
                flag = false;
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại! Đã xảy ra lỗi khi thêm", "THÔNG BÁO");
            }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Hãy chọn lại nhà cung cấp cần cập nhật!", "THÔNG BÁO");
                return;
            }
            btnLuu.Enabled = false;
            flag = false;
            string mancc = txtMa.Text.ToString().Trim();
            string ten = txtTen.Text.ToString().Trim();
            string diachi = txtDiachi.Text.ToString().Trim();
            string email = txtMail.Text.ToString().Trim();
            string sdt = txtSDT.Text.ToString().Trim();
            if (nhacungcap.SuaNhaCungCap(mancc, ten, diachi, email, sdt))
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "THÔNG BÁO");
                dataGridView_NCC.DataSource = nhacungcap.getNhaCungCap();
            }
            else
            {
                MessageBox.Show("Cập nhật nhà cung cấp thất bại! Đã xảy ra lỗi khi thêm", "THÔNG BÁO");
            }
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            flag = false;
            if (dataGridView_NCC.RowCount > 0)
            {
                string mancc = dataGridView_NCC.CurrentRow.Cells["MANCC"].Value.ToString().Trim();
                if (nhacungcap.XoaNhaCungCap(mancc))
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "THÔNG BÁO");
                    dataGridView_NCC.DataSource = nhacungcap.getNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại! Hãy xóa hết đơn hàng từ này cung cấp này", "THÔNG BÁO");
                }
            }
        }

        void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                txtMa.Text = "NCC" + nhacungcap.getNewID();
                txtTen.Text = "";
                txtDiachi.Text = "";
                txtMail.Text = "";
                txtSDT.Text = "";
                btnLuu.Enabled = true;
                flag = true;
            }
            else
            {
                txtMa.Text = "";
                txtTen.Text = "";
                txtDiachi.Text = "";
                txtMail.Text = "";
                txtSDT.Text = "";
                btnLuu.Enabled = false;
                flag = false;
            }
            
        }

        private void dataGridView_NCC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_NCC.RowCount > 0)
            {
                if (flag == true)
                {
                    btnLuu.Enabled = false;
                    flag = false;
                }
                txtMa.Text = dataGridView_NCC.CurrentRow.Cells["MANCC"].Value.ToString().Trim();
                if (dataGridView_NCC.CurrentRow.Cells["TEN_NCC"].Value != null)
                {
                    txtTen.Text = dataGridView_NCC.CurrentRow.Cells["TEN_NCC"].Value.ToString().Trim();
                }
                else
                {
                    txtTen.Text = "";
                }
                if (dataGridView_NCC.CurrentRow.Cells["DIACHI_NCC"].Value != null)
                {
                    txtDiachi.Text = dataGridView_NCC.CurrentRow.Cells["DIACHI_NCC"].Value.ToString().Trim();
                }
                else
                {
                    txtDiachi.Text = "";
                }
                if (dataGridView_NCC.CurrentRow.Cells["EMAIL_NCC"].Value != null)
                {
                    txtMail.Text = dataGridView_NCC.CurrentRow.Cells["EMAIL_NCC"].Value.ToString().Trim();
                }
                else
                {
                    txtMail.Text = "";
                }
                if (dataGridView_NCC.CurrentRow.Cells["SDT_NCC"].Value != null)
                {
                    txtSDT.Text = dataGridView_NCC.CurrentRow.Cells["SDT_NCC"].Value.ToString().Trim();
                }
                else
                {
                    txtSDT.Text = "";
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView_NCC.DataSource = nhacungcap.getNhaCungCap(txtSearch.Text.ToString().Trim());
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
        }
    }
}
