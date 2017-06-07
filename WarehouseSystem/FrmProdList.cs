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
        Product product = new Product();
        List<Shipping> prodList = new List<Shipping>();

        public FrmProdList()
        {
            InitializeComponent();
        }

        public FrmProdList(List<Shipping> list)
        {
            InitializeComponent();
            this.prodList = list;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshData();
        }

        private void RefreshData()
        {
           dgData.DataSource = repo.GetProductList();
        }

        private Product GetFocused()
        {
            return dgData.SelectedRows[0].DataBoundItem as Product;
        }

        private Product GetSelectedRows()
        {
            if (dgData.SelectedRows.Count == 0)
                return null;
            return dgData.SelectedRows[0].DataBoundItem as Product;
        }
        
        private void btnSendToShip_Click(object sender, EventArgs e)
        {
            product = GetSelectedRows();
            using (FrmSelectItem frm = new FrmSelectItem(product))
            {
                frm.ShowDialog(this);
            }
        }
    }
}
