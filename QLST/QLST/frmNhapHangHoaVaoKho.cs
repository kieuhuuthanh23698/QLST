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
    public partial class frmNhapHangHoaVaoKho : Form
    {
        DAL_HangHoa dal = new DAL_HangHoa();
        string maHangHoa;
        string malo;

        public frmNhapHangHoaVaoKho(string mahh)
        {
            this.maHangHoa = mahh;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuongThem.Text != "")
            {
                try
                {
                    dal.xuatKho(malo, maHangHoa, txtSoLuongThem.Text);
                    MessageBox.Show("Xuất hàng hóa thành công !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.frmDanhMucMatHang.refreshData();
                    Program.frmHoaDon.taiGridViewHangHoa();
                    this.Close();
                            
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xuất hàng hóa thất bại !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void txtSoLuongThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void frmNhapHangHoaVaoKho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.getLoHang(maHangHoa);
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (int.Parse(item.Cells["SOLUONGNHAP"].Value.ToString().Trim()) == int.Parse(item.Cells["SOLUONG_TRENQUAY"].Value.ToString().Trim()))
                {
                    item.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                }
                if(int.Parse(item.Cells["SOLUONGNHAP"].Value.ToString().Trim()) > int.Parse(item.Cells["SOLUONG_TRENQUAY"].Value.ToString().Trim()))
                {
                    item.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    txtSoLuongThem.Maximum = int.Parse(item.Cells["SOLUONGNHAP"].Value.ToString().Trim()) - int.Parse(item.Cells["SOLUONG_TRENQUAY"].Value.ToString().Trim());
                    malo = item.Cells["MALO"].Value.ToString().Trim();
                }
            }
        }
    }
}
