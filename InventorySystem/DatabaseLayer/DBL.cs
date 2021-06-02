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
        public static void NewPurchase(int supplierId,int PurchaseId,int ProductId,string productName,int categoryID,string categoryName,float PurchaseQuantity,float PurchaseUnitPrice,float saleUnitPrice,string quality) {

            SqlCommand cmd = new SqlCommand("NewPurchase",ConnOpen());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplierId",supplierId );
            cmd.Parameters.AddWithValue("@purchaseId", PurchaseId);
            cmd.Parameters.AddWithValue("@productId", ProductId);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@categoryId", categoryID);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@purchaseQuantity", PurchaseQuantity);
            cmd.Parameters.AddWithValue("@purchaseUnitPrice", PurchaseUnitPrice);
            cmd.Parameters.AddWithValue("@saleUnitPrice", saleUnitPrice);
            cmd.Parameters.AddWithValue("@Quality",quality );
            cmd.ExecuteNonQuery();
        }
    }
}