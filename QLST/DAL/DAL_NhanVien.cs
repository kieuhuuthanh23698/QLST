using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        QLSTDataContext context = new QLSTDataContext();

        public List<NHANVIEN> loadNV() {
            var kq = from nv in context.NHANVIENs
                     join tk in context.TAI_KHOANs
                     on nv.MANV equals tk.MANV select new {
                         nv.MANV, nv.TENNV, nv.NGAY_SINH,
                         nv.PHAI_NV, nv.EMAIL,
                         nv.DIACHI_NV, nv.LUONG, nv.CHUCVU,
                         tk.TENDN, tk.MATKHAU, tk.HOATDONG
                     };
            return kq.ToList().ConvertAll(t => new NHANVIEN() {
                MANV = t.MANV, TENNV = t.TENNV, NGAY_SINH = t.NGAY_SINH,
                PHAI_NV = t.PHAI_NV, EMAIL = t.EMAIL,
                DIACHI_NV = t.DIACHI_NV, LUONG = t.LUONG, CHUCVU = t.CHUCVU,
                TENDN = t.TENDN, MATKHAU = t.MATKHAU, HOATDONG = t.HOATDONG == 1 ? "ACTIVE":"DEACTIVE"
            }).ToList();
        }

        public List<NHANVIEN> searchNV(string tennv)
        {
            var kq = from nv in context.NHANVIENs where nv.TENNV.Contains(tennv)
                     join tk in context.TAI_KHOANs
                     on nv.MANV equals tk.MANV
                     select new
                     {
                         nv.MANV,
                         nv.TENNV,
                         nv.NGAY_SINH,
                         nv.PHAI_NV,
                         nv.EMAIL,
                         nv.DIACHI_NV,
                         nv.LUONG,
                         nv.CHUCVU,
                         tk.TENDN,
                         tk.MATKHAU,
                         tk.HOATDONG
                     };
            return kq.ToList().ConvertAll(t => new NHANVIEN()
            {
                MANV = t.MANV,
                TENNV = t.TENNV,
                NGAY_SINH = t.NGAY_SINH,
                PHAI_NV = t.PHAI_NV,
                EMAIL = t.EMAIL,
                DIACHI_NV = t.DIACHI_NV,
                LUONG = t.LUONG,
                CHUCVU = t.CHUCVU,
                TENDN = t.TENDN,
                MATKHAU = t.MATKHAU,
                HOATDONG = t.HOATDONG == 1 ? "ACTIVE" : "DEACTIVE"
            }).ToList();
        }

        private bool isExistNV(string maNV)
        {
            return context.NHANVIENs.Count(t => t.MANV.Equals(maNV)) > 0 ? true : false;
        }

        public string taoMaNV()
        {
            string maNV = "";
            int count = 1;
            do
            {
                if (!isExistNV("NV" + count))
                {
                    maNV = "NV" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maNV;
        }

        public bool checkUserName(string username) {
            return (context.TAI_KHOANs.Where(t => t.TENDN == username).ToList().Count > 0);
        }

        public void themNV(NHANVIEN nv) {
            context.NHANVIENs.InsertOnSubmit(nv);
            context.SubmitChanges();
            context.TAI_KHOANs.InsertOnSubmit(new TAI_KHOAN()
            {
                TENDN = nv.TENDN,
                MATKHAU = nv.MATKHAU,
                HOATDONG = nv.HOATDONG == "ACTIVE" ? 1 : 0,
                MANV = nv.MANV
            });
            context.SubmitChanges();
        }

        public void capNhatNhanVien(NHANVIEN nv) {
            NHANVIEN kq = context.NHANVIENs.Where(t => t.MANV == nv.MANV).FirstOrDefault();
            kq.TENNV = nv.TENNV;
            kq.CHUCVU = nv.CHUCVU;
            kq.PHAI_NV = nv.PHAI_NV;
            kq.DIACHI_NV = nv.DIACHI_NV;
            kq.EMAIL = nv.EMAIL;
            kq.NGAY_SINH = nv.NGAY_SINH;
            kq.LUONG = nv.LUONG;
            TAI_KHOAN kq1 = context.TAI_KHOANs.Where(t => t.MANV == nv.MANV).FirstOrDefault();
            kq1.MATKHAU = nv.MATKHAU;
            kq1.HOATDONG = nv.HOATDONG == "ACTIVE" ? 1 : 0;
            context.SubmitChanges();
        }

        public void deleteNhanVien(string manv) {
            TAI_KHOAN kq1 = context.TAI_KHOANs.Where(t => t.MANV == manv).FirstOrDefault();
            kq1.HOATDONG = 0;
            context.SubmitChanges();
        }
    }
}
