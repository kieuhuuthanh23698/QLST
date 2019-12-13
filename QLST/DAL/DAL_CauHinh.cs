using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_CauHinh
    {
        public DataTable getServerName()
        {
            DataTable tb = new DataTable();
            tb = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            return tb;
        }

        public DataTable getDatabaseName(string server, string user, string pass)
        {
            DataTable tb = new DataTable();
            try
            {
                string query = "SELECT * FROM sys.databases";
                string conectString = "Data Source=" + server + ";Initial Catalog=master; User ID=" + user + ";password=" + pass;
                SqlDataAdapter adap = new SqlDataAdapter(query, conectString);
                adap.Fill(tb);
            }
            catch (Exception)
            {
                return null;
            }
            return tb;
        }

        public void saveConfig(string server, string user, string pass, string database)
        {
            DAL.Properties.Settings.Default["QLSTConnectionString"] = @"Data Source=" + server + ";Initial Catalog=" + database + "; User ID=" + user + ";password=" + pass;
            DAL.Properties.Settings.Default.Save();
        }
    }
}
