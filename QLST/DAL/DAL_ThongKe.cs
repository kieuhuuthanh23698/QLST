using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_ThongKe
    {
        QLSTDataContext context = Context.getInstance();

        public List<HOA_DON> loadHoaDon() {
            return context.HOA_DONs.ToList();
        }

        public List<CHITIET_HD> loadCTHH(string mahd) {
            return context.CHITIET_HDs.Where(t => t.MAHD == mahd).ToList();
        }
    }
}
