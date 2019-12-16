using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_HoaDon
    {
        QLSTDataContext context = Context.getInstance();

        public List<HANGHOA> getHangHoa(string loaiHang) {
            var lstHangHoa = context.getHangHoa_Loai(maLoai(loaiHang));
            var kq = lstHangHoa.ToList().ConvertAll(t => new HANGHOA {
                MASP = t.MASP,
                TENSP = t.TENSP,
                GIA_BAN = (double)t.GIA_BAN,
                GIAMGIA = (double)t.GIAMGIA,
                GIA_BAN_1 = (double)t.GIA_BAN_1,
                DVT = t.DVT,
                SOLUONG = t.SOLUONG
            });
            return kq.ToList<HANGHOA>();
        }

        public string maLoai(string tenLoai) {
            if(tenLoai != "")
                return context.DANH_MUC_SPs.Where(t => t.TENLOAI.Trim().Equals(tenLoai.Trim())).First().MALOAI;
            return "";
        }

        public List<DANH_MUC_SP> getDanhMuc()
        {
            return context.DANH_MUC_SPs.Where(t => t.HIDDEN == 1).ToList();
        }

        public List<HANGHOA> searchHangHoa(string valueSearch)
        {
            var lstHangHoa = context.HANGHOAs.Where(t => t.TENSP.Contains(valueSearch) || t.MASP == valueSearch || t.MALOAI == valueSearch);
            var kq = lstHangHoa.ToList().ConvertAll(t => new HANGHOA
            {
                MASP = t.MASP,
                TENSP = t.TENSP,
                GIA_BAN = (double)t.GIA_BAN,
                DVT = t.DVT,
                SOLUONG = t.SOLUONG
            });
            return kq.ToList<HANGHOA>();
        }

        private bool isExistHoaDon(string maHD) {
            return context.HOA_DONs.Count(t => t.MAHD.Equals(maHD)) > 0 ? true : false;
        }

        public string taoMaHoaDon() {
            string maHD = "";
            int count = 1;
            do
            {
                if (!isExistHoaDon("HD" + count))
                {
                    maHD = "HD" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maHD;
        }

        public List<KHACH_HANG> getKhachHang() {
            return context.KHACH_HANGs.ToList();
        }

        public string getTichLuy(string MAKH) {
            if (context.KHACH_HANGs.Where(t => t.MAKH == MAKH).ToList().Count > 0)
                return (context.KHACH_HANGs.Where(t => t.MAKH == MAKH).ToList()[0].TICHLUY).ToString();
            else
                return "";
        }

        public void thanhToanHoaDon(string maHD, string maNV, string maKH, string tongTien, string dungDiemTichLuy, string tichDiem, List<CHITIET_HD> gioHang) {
            HOA_DON newHD = new HOA_DON();
            newHD.MAHD = maHD;
            newHD.MANV = maNV;
            newHD.MAKH = maKH;
            newHD.TONGTIEN = Double.Parse(tongTien);
            newHD.NGAYLAP = DateTime.Today;
            newHD.GIAMGIA = Double.Parse(dungDiemTichLuy);
            context.HOA_DONs.InsertOnSubmit(newHD);
            context.SubmitChanges();
            context.CHITIET_HDs.InsertAllOnSubmit(gioHang);
            foreach (var item in gioHang)
            {
                context.HANGHOAs.Where(t => t.MASP == item.MASP).FirstOrDefault().SOLUONG -= item.SL_MUA;
            }
            context.SubmitChanges();
            context.KHACH_HANGs.Where(t => t.MAKH == maKH).FirstOrDefault().TICHLUY += (int.Parse(tichDiem) - int.Parse(dungDiemTichLuy));

        }

        public bool TaoDonHang(string maDH, string maNCC, DateTime ngaylap, string ghichu, List<CHI_TIET_DDH> chitiet)
        {
            try
            {
                DON_DAT_HANG_NCC ddh = new DON_DAT_HANG_NCC();
                ddh.MADDH = maDH;
                ddh.MANCC = maNCC;
                ddh.NGAYDAT = ngaylap;
                ddh.GHICHU_DDH = ghichu;
                context.DON_DAT_HANG_NCCs.InsertOnSubmit(ddh);
                context.CHI_TIET_DDHs.InsertAllOnSubmit(chitiet);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                context = Context.getInstance();
                return false;
            }
        }
        public int getMaxIDDonDatHang()
        {
            if (context.DON_DAT_HANG_NCCs.Count() == 0)
                return 1;
            DON_DAT_HANG_NCC ddh = (from dh in context.DON_DAT_HANG_NCCs orderby dh.MADDH descending select dh).FirstOrDefault();
            return int.Parse(ddh.MADDH.ToString().Substring(3))+1;
        }
    }


}