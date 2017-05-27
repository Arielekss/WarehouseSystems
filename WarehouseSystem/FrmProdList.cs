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
        }

        private void RefreshData()
        {
            dgData.DataSource = repo.GetProductData();
        }

        


        /*  private List<NegativeMagazine> GetSelectedRows()
        {
            List<NegativeMagazine> selectedRows = magList.Where(x => x.IsChecked && IsNegativeMagazineToCorrection(x)).ToList();
            if (!selectedRows.Any())
            {
                Utils.ShowInfo(this, Strings.TxtBrakZaznaczonychPozycji);
            }
            return selectedRows;
        }
          
      }*/
        private void btnSendToShip_Click(object sender, EventArgs e)
        {
            /*
            foreach(Product prod in prodList)
            {
                
                prodList.Add(prod);
            }

            if (product == null)
            {
                MessageBox.Show(this, "Product is not choice");
                return;
            }
            using (FrmShippingList frm = new FrmShippingList(prodList))
            {
                frm.ShowDialog(this);
            }*/
        }
    }
}
