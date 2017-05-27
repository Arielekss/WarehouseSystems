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
    public partial class FrmShippingList : Form
    {
        Shipping ship = new Shipping();
        Product prod = new Product();
        List<Product> ProdList = new List<Product>();
        public FrmShippingList()
        {
            InitializeComponent();
        }

        public FrmShippingList(List<Product> prodList)
        {
            InitializeComponent();
            prod = product;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ship.ProductName = prod.ProductName;
            ship.Quantity = prod.Quantity;
            ship.Price = (decimal)ship.Quantity * prod.Price;
        }
    }
}
