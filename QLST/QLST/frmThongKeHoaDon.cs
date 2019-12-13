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
    public partial class frmThongKeHoaDon : Form
    {
        DAL_ThongKe dal = new DAL_ThongKe();
        public frmThongKeHoaDon()
        {
            InitializeComponent();
            TaidataGirdview();
        }

        public void TaidataGirdview()
        {
            try
            {
                dataGridView_PhieuBanHang.DefaultCellStyle.BackColor = Color.LightCyan;
                dataGridView_PhieuBanHang.DataSource = dal.loadHoaDon();    
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView_PhieuBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_PhieuBanHang.SelectedRows.Count != 0)
                {
                    dataGridViewChiTietHoaDon.DataSource = dal.loadCTHH(dataGridView_PhieuBanHang.SelectedRows[0].Cells["MAHD"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
