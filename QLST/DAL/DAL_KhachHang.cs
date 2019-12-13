using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        QLSTDataContext context = Context.getInstance();

        public List<KHACH_HANG> getKhachHang()
        {
            return context.KHACH_HANGs.ToList();
        }
        

        private bool isExistKH(string maKH)
        {
            return context.KHACH_HANGs.Count(t => t.MAKH.Equals(maKH)) > 0 ? true : false;
        }

        public string taoMaKH()
        {
            string maKH = "";
            int count = 1;
            do
            {
                if (!isExistKH("KH" + count))
                {
                    maKH = "KH" + count;
                    break;
                }
                count++;
            } while (count != 0);
            return maKH;
        }

        public void themKH(string makh, string tenkh, string diachi, string sdt, string email) {
            try
            {
                context.KHACH_HANGs.InsertOnSubmit(new KHACH_HANG() { MAKH = makh, TENKH = tenkh, DIACHI = diachi, SDT = sdt, EMAIL = email, TICHLUY = 0 });
                context.SubmitChanges();
            }
            catch (Exception ex) { }
        }
    }
}
