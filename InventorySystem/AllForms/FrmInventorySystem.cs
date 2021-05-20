using InventorySystem.AllForms.StockForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.AllForms
{
    public partial class FrmInventorySystem : Form
    {
        public FrmInventorySystem()
        {
            InitializeComponent();
        }

        private void FrmInventorySystem_Load(object sender, EventArgs e)
        {
            tsslabelDateTime.Text = DateTime.Now.ToString("dddd MMMM yyyy hh:mm:ss");
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.ShowDialog();
        }
    }
}
