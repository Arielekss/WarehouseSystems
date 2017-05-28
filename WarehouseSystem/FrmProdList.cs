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

        private List<Product> GetSelectedRows()
        {
            List<Product> selectedRows = new List<Product>(); //prodList.Where(x => x.IsChecked && ).ToList();
            foreach (Product prod in prodList)
            {
                Product prodSelected = GetFocused();
                if(prod.Id == prodSelected.Id)
                selectedRows.Add(prod);
            }
                if (!selectedRows.Any())
                    MessageBox.Show("Please, choice product from list");

            return selectedRows;
        }


        private void btnSendToShip_Click(object sender, EventArgs e)
        {
            List<Product> prodToShipList = GetSelectedRows();
            if (!prodToShipList.Any())
            {
                MessageBox.Show(this, "Product is not choice");
                return;
            }
            using (FrmShippingList frm = new FrmShippingList(prodToShipList))
            {
                frm.ShowDialog(this);
            }
        }
    }
}
