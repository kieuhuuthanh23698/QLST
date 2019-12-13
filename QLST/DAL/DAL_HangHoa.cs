using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HangHoa
    {
        QLSTDataContext context = new QLSTDataContext();

        private bool isExisLoaiHH(string maLoaiHH)
        {
            return context.DANH_MUC_SPs.Count(t => t.MALOAI.Equals(maLoaiHH)) > 0 ? true : false;
        }

        public string taoMaLoaiHH()
        {
            string maLoaiHH = "";
            int count = 1;
            do
            {
                if (!isExisLoaiHH("LOAI" + count))
                {
                    maLoaiHH = "LOAI" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maLoaiHH;
        }

        public void themLoaiHH(string maLoaiHH, string tenLoaiHHH) {
            DANH_MUC_SP dm = new DANH_MUC_SP();
            dm.MALOAI = maLoaiHH;
            dm.TENLOAI = tenLoaiHHH;
            dm.HIDDEN = 1;
            context.DANH_MUC_SPs.InsertOnSubmit(dm);
            context.SubmitChanges();
            System.Threading.Thread.Sleep(1000);
        }

        public int canDelete(string tenLoai) {
            List<DANH_MUC_SP> a = context.DANH_MUC_SPs.Where(t => t.TENLOAI == tenLoai).ToList();
            if (a.Count == 1)
            {
                List<HANGHOA> lstHH = context.HANGHOAs.Where(t => t.MALOAI == a[0].MALOAI).ToList();
                int soLuongHangHoa_Loai = lstHH.Count;
                if (soLuongHangHoa_Loai == 0)
                {
                    context.DANH_MUC_SPs.DeleteOnSubmit(a[0]);
                    context.SubmitChanges();
                    return soLuongHangHoa_Loai;
                }
                else
                {
                    a[0].HIDDEN = 0;
                    if (lstHH.Find(t => t.SOLUONG > 0) != null)
                        return -2;
                    else
                    {
                        lstHH.ForEach(t => t.HIDDEN = 0);
                        context.SubmitChanges();
                        return soLuongHangHoa_Loai;
                    }
                }
            }
            return -1;
        }

        public int xoaHangHoa(string masp) {
            HANGHOA kq = context.HANGHOAs.Where(t => t.MASP == masp).First();
            if (kq.SOLUONG > 0)
                return -1;
            else
            {
                kq.HIDDEN = 0;
                context.SubmitChanges();
            }
            return 1;

        }
            
        public void doiTenLoaiHangHoa(string tenLoaiHH, string value) {
            DANH_MUC_SP kq = context.DANH_MUC_SPs.Where(t => t.TENLOAI.Trim() == tenLoaiHH.Trim()).First();
            kq.TENLOAI = value;
            context.SubmitChanges();
            System.Threading.Thread.Sleep(1000);
        }

        private bool isExisHH(string maHH)
        {
            return context.HANGHOAs.Count(t => t.MASP.Equals(maHH)) > 0 ? true : false;
        }

        public string taoMaHangHoa(string maLoai)
        {
            string maHH = "";
            int count = 1;
            do
            {
                if (!isExisHH(maLoai+ "_" + count))
                {
                    maHH = maLoai + "_" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maHH;
        }

        public void themHangHoa(string maLoai, string masp, string tensp, string dvt, string giaban) {
            HANGHOA sp = new HANGHOA();
            sp.MALOAI = maLoai;
            sp.MASP = masp;
            sp.TENSP = tensp;
            sp.DVT = dvt;
            sp.SOLUONG = 0;
            sp.HIDDEN = 1;
            context.HANGHOAs.InsertOnSubmit(sp);
            context.SubmitChanges();
            context.BANG_GIAs.InsertOnSubmit(new BANG_GIA() { MASP = masp, GIA_BAN = Double.Parse(giaban), NGAYBD = DateTime.Today});
            context.SubmitChanges();
        }

        public string updateHH(string maHH, string tenHH, string dvt, string giaBan) {
            HANGHOA sp = context.HANGHOAs.Where(t => t.MASP == maHH).First();
            sp.TENSP = tenHH;
            sp.DVT = dvt;
            context.SubmitChanges();
            try
            {
                if (context.BANG_GIAs.Where(t => t.MASP == maHH && t.NGAYBD == DateTime.Today).ToList().Count == 0)
                {
                    context.BANG_GIAs.InsertOnSubmit(new BANG_GIA() { MASP = maHH, GIA_BAN = Double.Parse(giaBan), NGAYBD = DateTime.Today });
                    context.SubmitChanges();
                }
                else
                    return "Không thể cập nhật giá 2 lần trong 1 ngày ";
            }
            catch (Exception ex) {
                return ex.ToString();
            }
            return "Cập nhật thông tin hàng hóa thành công !";

        }

        public List<LO_HANG> getLoHang(string masp) {
            return context.LO_HANGs.Where(t => t.MASP == masp).ToList();
        }

        public void xuatKho(string malo, string masp, string value) {
            context.LO_HANGs.Where(t => t.MALO == malo).First().SOLUONG_TRENQUAY += int.Parse(value);
            context.HANGHOAs.Where(t => t.MASP == masp).First().SOLUONG += int.Parse(value);
            context.SubmitChanges();
        }
    }
}
