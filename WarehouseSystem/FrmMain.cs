using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSystem
{
    public partial class FrmMain : Form
    {
        ProductRepository repo = new ProductRepository();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            using (FrmAddProd frm = new FrmAddProd())
            {
                frm.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnAddShip_Click(object sender, EventArgs e)
        {
            using (FrmProdList frm = new FrmProdList())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
