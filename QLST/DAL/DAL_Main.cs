using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_Main
    {
        QLSTDataContext context = Context.getInstance();

        public string getNameNV(string maNV) {
            NHANVIEN result = context.NHANVIENs.Where(tk => tk.MANV == maNV).FirstOrDefault();
            return result.TENNV;
        }

        //public List<MAN_HINH> getManHinh() {
            
        //}
    }
}
