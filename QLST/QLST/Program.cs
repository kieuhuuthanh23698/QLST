using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLST
{
    static class Program
    {
        public static frmLogin frmLogin = null;
        public static frmKetNoi frmCauHinh = null;
        public static frmDoiMatKhau frmDoiMatKhau = null;
        public static frmMain frmMain = null;
        //form business
        public static frmHoaDon frmHoaDon = null;
        //form danh mục
        public static frmDanhMucMatHang frmDanhMucMatHang = null;
            public static frmThemNhomMatHang frmThemNhomMatHang = null;
            public static frmThemSanPham frmThemSanPham = null;
            public static frmSuaHangHoa frmSuaHangHoa = null;
            public static frmNhapHangHoaVaoKho frmNhapHangHoaVaoKho = null;
        public static frmDoiTenNhomMatHang frmDoiTenNhomMatHang = null;
        public static frmDanhMucKhachHang frmDanhMucKhachHang = null;
        public static frmDanhMucNhanVien frmDanhMucNhanVien = null;
        //form thống kê
        public static frmThongKeHoaDon frmThongKeHoaDon = null;

        //form phan quyen
        public static frmPhanQuyen frmPhanQuyen = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new frmLogin();
            Application.Run(frmLogin);
        }
    }
}
