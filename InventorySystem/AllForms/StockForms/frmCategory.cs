using InventorySystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.AllForms.StockForms
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
            FillGrid();
        }
        private void SetColoumnsWidth() {
            dgvCategoryList.Columns[0].Width = 100;
            dgvCategoryList.Columns[1].Width = 200;
            dgvCategoryList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            FillGrid();
            SetColoumnsWidth();
        }
        private void FillGrid() {
            DataTable dt = new DataTable();
            dgvCategoryList.Rows.Clear();
            dt = DBL.RetrieveData("Select * from Categories");
            if (dt.Rows.Count > 0) {
                foreach (DataRow category in dt.Rows) {
                    dgvCategoryList.Rows.Add(Convert.ToString(category[0]), Convert.ToString(category[1]), Convert.ToString(category[2]));
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            epCategory.Clear();
            if (txtCategory.Text.Trim().Length == 0)
            {
                epCategory.SetError(txtCategory,"Please Enter Category Name");
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
            string query = string.Format("insert into Categories(Name,[Description]) values ('{0}','{1}')",txtCategory.Text.Trim(),txtDescription.Text.Trim());
            DBL.InsertData(query);
            ClearForm();
            FillGrid();
            MessageBox.Show("Category Added Successfully", "Inventory System");
        }
        private void ClearForm() {
            txtDescription.Clear();
            txtCategory.Clear();
        }
    }
}
