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
        List<Product> prodList = new List<Product>();

        public FrmProdList()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshData();
            prodList = repo.GetProductList();
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
           
            /*using (FrmShippingList frm = new FrmShippingList(prodToShipList))
            {
                frm.ShowDialog(this);
            }*/
        }
    }
}
