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
    public partial class frmPhanQuyen : Form
    {
        QLSTDataContext context = Context.getInstance();
        DAL_PhanQuyen dal = new DAL_PhanQuyen();

        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            dgvNhomNguoiDung.DataSource = context.NHOM_NGUOI_DUNGs.ToList();
        }

        private void dgvNhomNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhomNguoiDung.SelectedRows.Count > 0)
            {
                string maNhom = dgvNhomNguoiDung.SelectedRows[0].Cells["MaNhom"].Value.ToString();
                dgvNguoiDung.DataSource = context.getTaiKhoan_Nhom(maNhom);
                dgvPhanQuyen.DataSource = context.getQuyen_Nhom(maNhom);
            }
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
                {
                    string value = senderGrid.Rows[e.RowIndex].Cells["Thuoc"].Value.ToString().Trim();
                    if (value.Equals("0"))
                    {
                        if (dgvNhomNguoiDung.SelectedRows.Count > 0)
                        {
                            string manv = senderGrid.Rows[e.RowIndex].Cells["MANV"].Value.ToString().Trim();
                            string maNhom = dgvNhomNguoiDung.SelectedRows[0].Cells["MaNhom"].Value.ToString().Trim();
                            dal.themNguoiDungVaoNhomm(manv, maNhom);
                            MessageBox.Show("Đã thêm nhân viên " + manv + " vào nhóm " + maNhom);
                            senderGrid.Rows[e.RowIndex].Cells["Thuoc"].Value = "1";
                        }
                    }
                    else
                    {
                        if (dgvNhomNguoiDung.SelectedRows.Count > 0)
                        {
                            string manv = senderGrid.Rows[e.RowIndex].Cells["MANV"].Value.ToString().Trim();
                            string maNhom = dgvNhomNguoiDung.SelectedRows[0].Cells["MaNhom"].Value.ToString().Trim();
                            dal.xoaNguoiDungTrongNhomm(manv, maNhom);
                            MessageBox.Show("Đã xóa nhân viên " + manv + " khỏi nhóm " + maNhom);
                            senderGrid.Rows[e.RowIndex].Cells["Thuoc"].Value = "0";
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                string value = senderGrid.Rows[e.RowIndex].Cells["Quyen"].Value.ToString().Trim();
                if (value.Equals("0"))
                {
                    if (dgvNhomNguoiDung.SelectedRows.Count > 0)
                    {
                        string maManHinh = senderGrid.Rows[e.RowIndex].Cells["MaManHinh"].Value.ToString().Trim();
                        string maNhom = dgvNhomNguoiDung.SelectedRows[0].Cells["MaNhom"].Value.ToString().Trim();
                        dal.capQuyenChoNhom(maManHinh, maNhom);
                        MessageBox.Show("Đã cấp quyền màn hình " + maManHinh + " vào nhóm " + maNhom);
                        senderGrid.Rows[e.RowIndex].Cells["Quyen"].Value = "1";
                    }
                    
                }
                else
                {
                    if (dgvNhomNguoiDung.SelectedRows.Count > 0)
                    {
                        string maManHinh = senderGrid.Rows[e.RowIndex].Cells["MaManHinh"].Value.ToString().Trim();
                        string maNhom = dgvNhomNguoiDung.SelectedRows[0].Cells["MaNhom"].Value.ToString().Trim();
                        dal.huyQuyenKhoiNhom(maManHinh, maNhom);
                        MessageBox.Show("Đã hủy quyền màn hình " + maManHinh + " khỏi nhóm " + maNhom);
                        senderGrid.Rows[e.RowIndex].Cells["Quyen"].Value = "0";
                    }
                }
            }
        }
    }
}