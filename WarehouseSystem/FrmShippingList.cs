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
        List<Product> ProdList = new List<Product>();
        List<Shipping> ShipList = new List<Shipping>();
        public FrmShippingList()
        {
            InitializeComponent();
        }

        public FrmShippingList(List<Product> prodList)
        {
            InitializeComponent();
            ProdList = prodList;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach(Product prod in ProdList)
            {
                ship.ProductName = prod.ProductName;
                ship.Quantity = prod.Quantity;
                ship.Price = (decimal)ship.Quantity * prod.Price;
                ShipList.Add(ship);
            }
            RefreshData();
        }

        private void RefreshData()
        {
            dgData.DataSource = ShipList;
        }
    }
}
