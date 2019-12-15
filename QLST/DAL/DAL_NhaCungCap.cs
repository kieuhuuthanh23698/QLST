using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        QLSTDataContext context = Context.getInstance();
        public List<NHA_CUNG_CAP> getNhaCungCap()
        {
            return context.NHA_CUNG_CAPs.ToList();
        }
        public List<NHA_CUNG_CAP> getNhaCungCap(string key_world)
        {
            return (from ncc in context.NHA_CUNG_CAPs where (ncc.MANCC.Contains(key_world) || ncc.TEN_NCC.Contains(key_world)) select ncc).ToList();
        }
        public int getNewID()
        {
            if (context.NHA_CUNG_CAPs.Count() == 0)
            {
                return 1;
            }
            else
            {
                NHA_CUNG_CAP nhacc = (from ncc in context.NHA_CUNG_CAPs orderby ncc.MANCC descending select ncc).FirstOrDefault();
                string t = nhacc.MANCC;
                t = t.Substring(3).Trim();
                return int.Parse(t)+1;
            }
        }
        public bool XoaNhaCungCap(string MaNCC)
        {
            if (context.DON_DAT_HANG_NCCs.Where(t => t.MANCC == MaNCC).Count()>0)
                return false;
            try
            {
                NHA_CUNG_CAP ncc = context.NHA_CUNG_CAPs.Where(t => t.MANCC == MaNCC).FirstOrDefault();
                if (ncc != null)
                {
                    context.NHA_CUNG_CAPs.DeleteOnSubmit(ncc);
                }
                context.SubmitChanges();
                return true;
            }
            catch
            {
                context = Context.getInstance();
                return false;
            }
        }
        public bool ThemNhaCungCap(string MaNCC, string tenncc, string daichi, string email, string dienthoai)
        {
            try
            {
                NHA_CUNG_CAP ncc = new NHA_CUNG_CAP();
                ncc.MANCC = MaNCC;
                ncc.TEN_NCC=(tenncc==""?null:tenncc);
                ncc.DIACHI_NCC = (daichi == "" ? null : daichi);
                ncc.EMAIL_NCC = (email == "" ? null : email);
                ncc.SDT_NCC = (dienthoai == "" ? 0 : decimal.Parse(dienthoai));
                context.NHA_CUNG_CAPs.InsertOnSubmit(ncc);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                context = Context.getInstance();
                return false;
            }
        }
        public bool SuaNhaCungCap(string MaNCC, string tenncc, string daichi, string email, string dienthoai)
        {
            try
            {
                NHA_CUNG_CAP ncc = context.NHA_CUNG_CAPs.Where(t => t.MANCC == MaNCC).FirstOrDefault();
                if (ncc != null)
                {
                    ncc.TEN_NCC = (tenncc == "" ? null : tenncc);
                    ncc.DIACHI_NCC = (daichi == "" ? null : daichi);
                    ncc.EMAIL_NCC = (email == "" ? null : email);
                    ncc.SDT_NCC = (dienthoai == "" ? 0 : decimal.Parse(dienthoai));
                    context.SubmitChanges();
                }
                return true;
            }
            catch
            {
                context = Context.getInstance();
                return false;
            }
        }
    }
}
