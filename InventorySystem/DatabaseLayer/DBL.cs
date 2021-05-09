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
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(@"Data Source=DESKTOP-44MS589\SQLEXPRESS;Initial Catalog=InventorySystem;Integrated Security=True");
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex) {
                return null;
            }
        }
        public static void InsertData(string query) {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                
            }
        }
        public static void DeleteData(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
        public static DataTable RetrieveData(string query) {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex) {
                return null;
            }
        }
    }
}