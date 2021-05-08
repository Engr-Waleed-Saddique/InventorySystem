using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InventorySystem.DatabaseLayer
{
    public class DBL
    {
        private static SqlConnection con;
        public static SqlConnection ConnOpen() 
        {
            if (con == null) {
                con = new SqlConnection(@"Data Source=DESKTOP-44MS589\SQLEXPRESS;Initial Catalog=InventorySystem;Integrated Security=True");
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
        public static void InsertData(string query) {
            SqlCommand cmd = new SqlCommand(query,ConnOpen());
            cmd.ExecuteNonQuery();
        }
        public static DataTable RetrieveData(string query) {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
            da.Fill(dt);
            return dt;
        }
    }
}
