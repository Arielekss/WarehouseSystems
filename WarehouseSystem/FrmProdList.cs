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
    public partial class FrmProdList : Form
    {
        ProductRepository repo = new ProductRepository();
        public FrmProdList()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshData();
        }

        private void RefreshData()
        {
            dgData.DataSource = repo.GetProductData();
        }
    }
}
