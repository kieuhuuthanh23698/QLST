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
    public partial class frmDanhMucNhanVien : Form
    {
        DAL_NhanVien dal = new DAL_NhanVien();
        List<NHANVIEN> list;

        public frmDanhMucNhanVien()
        {
            InitializeComponent();
            list = dal.loadNV();
            TaiNV();
            taiAutoCompleteText();
            //if (kTraAdmin("",manv) == false)
            //{
            //    txtMatkhau.PasswordChar = '*';
            //    cbbCap.Enabled = false;
            //    txtUsers.Enabled = false;
            //    txtMatkhau.Enabled = false;
            //}
            btnHuyThem.Hide();
        }

        public void TaiNV()
        {
            try
            {
                dataGridView_Nhanvien.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMa.Focus();
            btnHuyThem.Show();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dataGridView_Nhanvien.Enabled = false;

            //reset các text box thông tin
            clearControl();
            txtMa.Text = dal.taoMaNV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Nhanvien.SelectedRows.Count != 0)
                {
                    if (verifyData())
                    {
                        
                        dal.capNhatNhanVien(getData());
                        list = dal.loadNV();
                        TaiNV();
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "CẬP NHẬT THÔNG TIN NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại!", "CẬP NHẬT THÔNG TIN NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                   }
                    else
                        MessageBox.Show("Bạn chọn nhân viên trong danh sách và sửa lại thì mới cập nhật thông tin được !", "CẬP NHẬT THÔNG TIN NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool KTMail(string s)
        {
            char[] mangchuoi = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                if (mangchuoi[i] == '@')
                    return true;
            return false;
        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            string[] active = { "ACTIVE", "DEACTIVE"};
            foreach (string s in active)
            {
                cbbActive.Items.Add(s);
            }
            string[] gtinh = { "Nam", "Nữ" };
            foreach (string s in gtinh)
            {
                cboxGtinh.Items.Add(s);
            }
        }

        private void dataGridView_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_Nhanvien.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView_Nhanvien.SelectedRows[0];
                    string tennv = row.Cells["TENNV"].Value.ToString().Trim();
                    NHANVIEN a = dal.searchNV(tennv)[0];
                    txtMa.Text = a.MANV;
                    txtTen.Text = a.TENNV;
                    dateTimeNgaySinh.Value = (DateTime)a.NGAY_SINH;
                    cboxGtinh.SelectedIndex = a.PHAI_NV;
                    txtMail.Text = a.EMAIL;
                    txtDiachi.Text = a.DIACHI_NV;
                    txtLuong.Text = a.LUONG + "";
                    txtChucVu.Text = a.CHUCVU;
                    txtUsers.Text = a.TENDN;
                    txtMatkhau.Text = a.MATKHAU;
                    cbbActive.SelectedIndex = a.HOATDONG == "ACTIVE" ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //int r = dataGridView_Nhanvien.CurrentCell.RowIndex;

                //string maNV = dataGridView_Nhanvien.Rows[r].Cells[0].Value.ToString();
                if (dataGridView_Nhanvien.SelectedRows.Count > 0)
                {
                    if (frmLogin.nhanVien.MANV != txtMa.Text)
                    {
                        dal.deleteNhanVien(txtMa.Text);
                    MessageBox.Show("Đã deactive nhân viên", "XÓA NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    list = dal.loadNV();
                    TaiNV();
                    //    //reset lại các text box vì nó vẫn còn chứa các thông tin của nhân viên vừa xóa
                    clearControl();
                    }
                    else
                        MessageBox.Show("Bạn đăng nhập bằng tài khoảng này ! Không thể xóa được !", "XÓA NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KTMail(txtMail.Text) == false)
            {
                MessageBox.Show("Định dạng mail phải có ký tự @! Vui lòng nhập đúng định dạng tenmail@gmail.com", "MAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
            }
            else
            {
                if (verifyData())
                {
                    if (dal.checkUserName(txtUsers.Text) == true)
                    {
                        MessageBox.Show("Tên đăng nhập không hợp lệ !", "THÊM NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //ko them
                    }
                    else
                    {
                        //thêm nhân vien
                        dal.themNV(getData());
                        MessageBox.Show("Thêm nhân viên thành công !", "THÊM NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        list = dal.loadNV();
                        TaiNV();
                        clearControl();

                        btnLuu.Enabled = false;
                        btnHuyThem.Hide();
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        dataGridView_Nhanvien.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin của nhân viên!", "THÊM NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            //reset các text box thông tin
            clearControl();

            btnHuyThem.Hide();
            dataGridView_Nhanvien.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        public bool verifyData() {
            return (txtMa.Text != "" &&
                    txtTen.Text != "" &&
                    KTMail(txtMail.Text) &&
                    txtChucVu.Text != "" &&
                    txtDiachi.Text != "" &&
                    txtLuong.Text != "" &&
                    txtUsers.Text != "" &&
                    txtMatkhau.Text != "" &&
                    dateTimeNgaySinh.Text != "");
        }

        public void clearControl() {
            txtMa.Text = "";
            txtTen.Text = "";
            dateTimeNgaySinh.Value = DateTime.Now;
            cboxGtinh.SelectedIndex = 0;
            txtMail.Text = "";
            txtDiachi.Text = "";
            txtLuong.Text = "";
            txtChucVu.Text = "";
            txtUsers.Text = "";
            txtMatkhau.Text = "";
            cbbActive.SelectedIndex = 0;
        }

        public NHANVIEN getData() {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = txtMa.Text;
            nv.TENNV = txtTen.Text;
            nv.CHUCVU = txtChucVu.Text;
            nv.PHAI_NV = cboxGtinh.Text == "Nam" ? 0 : 1;
            nv.DIACHI_NV = txtDiachi.Text;
            nv.EMAIL = txtMail.Text;
            nv.NGAY_SINH = dateTimeNgaySinh.Value;
            nv.LUONG = Double.Parse(txtLuong.Text);
            nv.TENDN = txtUsers.Text;
            nv.MATKHAU = txtMatkhau.Text;
            nv.HOATDONG = cbbActive.Text;
            return nv;
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        public void taiAutoCompleteText()
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    txtTimtenNv.AutoCompleteCustomSource.Add(list[i].TENNV);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTimtenNv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimtenNv.Text.Trim().Equals("") == true)
                    TaiNV();
                else
                    dataGridView_Nhanvien.DataSource = dal.searchNV(txtTimtenNv.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
    }
}