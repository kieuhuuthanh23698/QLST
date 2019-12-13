using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public enum LoginResult
    {
        Disabled, Invalid, Success
    }

    public class DAL_Login
    {
        QLSTDataContext context = Context.getInstance();

        public int checkConfig()
        {
            if (DAL.Properties.Settings.Default.QLSTConnectionString == "")
                return 1;
            try
            {
                SqlConnection conn = new SqlConnection(DAL.Properties.Settings.Default.QLSTConnectionString);
                conn.Open();
                return 0;
            }
            catch (Exception)
            {
                return 2;
            }
        }

        public LoginResult checkUser(string userName, string passWord)
        {
            TAI_KHOAN result = context.TAI_KHOANs.Where(tk => tk.TENDN == userName && tk.MATKHAU == passWord).FirstOrDefault();
            if (result == null)
                return LoginResult.Invalid;
            else
            {
                if(result.HOATDONG == 0)
                    return LoginResult.Disabled; 
                return LoginResult.Success;
            }
        }

        public TAI_KHOAN getTaiKhoan(string userName, string passWord)
        {
            TAI_KHOAN result = context.TAI_KHOANs.Where(tk => tk.TENDN == userName && tk.MATKHAU == passWord).FirstOrDefault();
            return result;
        }


        public bool changePassword(string user, string pass) {
            try {
                context.TAI_KHOANs.Where(t => t.TENDN == user).FirstOrDefault().MATKHAU = pass;
                context.SubmitChanges();
            } catch (Exception) {
                return false;
            }
            return true;
        }
    }
}
