using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class dalNhapHang
    {
        QLSTDataContext qlst = new QLSTDataContext();
        private bool isExistPhieuNhap(string maPN)
        {
            return qlst.PHIEUNHAPs.Count(t => t.MAPN.Equals(maPN)) > 0 ? true : false;
        }
        public List<DON_DAT_HANG_NCC> getdondathang()
        {
            return qlst.DON_DAT_HANG_NCCs.Select(t => t).ToList();
        }
        public string TaoMaPhieuNhap()
        {
            string maPN = "";
            int count = 1;
            do
            {
                if (!isExistPhieuNhap("PN" + count))
                {
                    maPN = "PN" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maPN;
        }
        private bool isExistLo(string ma)
        {
            return qlst.LO_HANGs.Count(t => t.MALO.Equals(ma)) > 0 ? true : false;
        }
        public string TaoMaLoHang()
        {
            string maLo = "";
            int count = 1;
            do
            {
                if (!isExistLo("LH" + count))
                {
                    maLo = "LH" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maLo;
        }
        public bool ThemPhieuNhap(PHIEUNHAP pn)
        {
            try
            {
                pn.TONGTIEN_PN = 0;
                qlst.PHIEUNHAPs.InsertOnSubmit(pn);
                qlst.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public List<HANGHOA> LoadCboSP()
        {
            return qlst.HANGHOAs.Select(t => t).ToList<HANGHOA>();
        }
        public bool KTSPTrongKho(string mapn, string ma)
        {
            var p = qlst.LO_HANGs.Where(t=>t.MAPN == mapn).Where(t=>t.MASP == ma).FirstOrDefault();
            if (p == null)
            {
                return true;
            }
            else { return false; }
        }
        
        public bool ThemSPvaoLoHang(LO_HANG p)
        {
            try
            {
                if (KTSPTrongKho(p.MAPN, p.MASP))
                {
                    p.MALO = TaoMaLoHang();
                    p.SOLUONG_TRENQUAY = 0;
                    qlst.LO_HANGs.InsertOnSubmit(p);
                    qlst.SubmitChanges();
                    return true;
                }
                else
                {
                    LO_HANG k = qlst.LO_HANGs.Where(t => t.MAPN == p.MAPN).Where(t => t.MASP == p.MASP).FirstOrDefault();
                    k.SOLUONGNHAP = k.SOLUONGNHAP + p.SOLUONGNHAP;
                    qlst.SubmitChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        public List<LO_HANG> LoadLoHang(string ma)
        {
            //var ds = (from p in qlst.LO_HANGs
            //          join q in qlst.HANGHOAs on p.MASP equals q.MASP
            //          select new
            //          {
            //              MALO = p.MALO,
            //              MASP = p.MASP,
            //              MAPN = p.MAPN,
            //              NGAYSX = p.NGAYSX,
            //              HANSD = p.HANSD,
            //              SOLUONGNHAP = p.SOLUONGNHAP,
            //              SOLUONG_TRENQUAY = p.SOLUONG_TRENQUAY,
            //              DONGIA_NHAP = p.DONGIA_NHAP,
            //              TENSP = p.HANGHOA.TENSP
            //          });
            //var kq = ds.ToList().ConvertAll(t => new LO_HANG()
            //{
            //    MALO = t.MALO,
            //    MASP = t.MASP,
            //    MAPN = t.MAPN,
            //    NGAYSX = t.NGAYSX,
            //    HANSD = t.HANSD,
            //    SOLUONGNHAP = t.SOLUONGNHAP,
            //    SOLUONG_TRENQUAY = t.SOLUONG_TRENQUAY,
            //    DONGIA_NHAP = t.DONGIA_NHAP,
            //    TENSP = t.TENSP
            //});
            //return kq.Where(t => t.MAPN == ma).ToList<LO_HANG>();
            return qlst.LO_HANGs.Where(t => t.MAPN == ma).ToList<LO_HANG>();
        }
        public void UpdateTongTien(string ma,double k)
        {
            PHIEUNHAP p = qlst.PHIEUNHAPs.Where(t => t.MAPN == ma).FirstOrDefault();
            p.TONGTIEN_PN = p.TONGTIEN_PN + k;
            qlst.SubmitChanges();
        }
        public string TongTien(string ma)
        {
            PHIEUNHAP k = qlst.PHIEUNHAPs.Where(t => t.MAPN == ma).FirstOrDefault();
            return k.TONGTIEN_PN.ToString();
        }
        public bool XoaSp(string masp, string mapn, double sl)
        {
            try
            {
                PHIEUNHAP p = qlst.PHIEUNHAPs.Where(t => t.MAPN == mapn).FirstOrDefault();
                p.TONGTIEN_PN = p.TONGTIEN_PN - sl;
                LO_HANG k = qlst.LO_HANGs.Where(t => t.MASP == masp).FirstOrDefault();
                qlst.LO_HANGs.DeleteOnSubmit(k);
                qlst.SubmitChanges();
                return true;
            }
            catch { return false; }

        }
    }
}
