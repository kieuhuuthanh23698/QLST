using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhanQuyen
    {
        QLSTDataContext context = Context.getInstance();

        public List<NHOM_NGUOI_DUNG> getNhomNguoiDung() {
            return context.NHOM_NGUOI_DUNGs.ToList();
        }

        public void themNguoiDungVaoNhomm(string manv, string maNhom) {
            string tendn = context.TAI_KHOANs.Where(t => t.MANV == manv).First().TENDN;
            context.NGUOIDUNG_NHOM_NDs.InsertOnSubmit(new NGUOIDUNG_NHOM_ND() { TenDangNhap = tendn, MaNhomNguoiDung = maNhom});
            context.SubmitChanges();
        }

        public void xoaNguoiDungTrongNhomm(string manv, string maNhom)
        {
            string tendn = context.TAI_KHOANs.Where(t => t.MANV == manv).First().TENDN;
            context.NGUOIDUNG_NHOM_NDs.DeleteOnSubmit(context.NGUOIDUNG_NHOM_NDs.Where(t => t.TenDangNhap == tendn && t.MaNhomNguoiDung == maNhom).First());
            context.SubmitChanges();
        }

        public void capQuyenChoNhom(string maManHinh, string maNhom) {
            context.PHAN_QUYENs.InsertOnSubmit(new PHAN_QUYEN() { MaManHinh = maManHinh, MaNhomNguoiDung = maNhom });
            context.SubmitChanges();
        }

        public void huyQuyenKhoiNhom(string maManHinh, string maNhom) {
            context.PHAN_QUYENs.DeleteOnSubmit(context.PHAN_QUYENs.Where(t => t.MaManHinh == maManHinh && t.MaNhomNguoiDung == maNhom).First());
            context.SubmitChanges();
        }
    }
}
