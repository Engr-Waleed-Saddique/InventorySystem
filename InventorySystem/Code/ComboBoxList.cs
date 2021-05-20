using InventorySystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Code
{
    public class ComboBoxList
    {
        public static void CategoryList(ComboBox cmbCategory) {
            DataTable dt = new DataTable();
            cmbCategory.Items.Add("Select Category");
            dt = DBL.RetrieveData("Select * from Categories");
            if (dt.Rows.Count > 0) {
                foreach (DataRow category in dt.Rows) {
                    cmbCategory.Items.Add(Convert.ToString(category[1]));
                }
            }
            cmbCategory.SelectedIndex = 0;
        }
    }
}