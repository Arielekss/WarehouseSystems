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
    public partial class FrmSelectItem : Form
    {
        Product product = new Product();
        Shipping shiping = new Shipping();

        public FrmSelectItem()
        {
            InitializeComponent();
        }

        public FrmSelectItem(Product product)
        {
            InitializeComponent();
            this.product = product;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MapValue(product);
        }
        private void MapValue(Product product)
        {
            txtProdSelName.Text = product.ProductName;
            shiping.ProductName = txtProdSelName.Text;
            txtProdSelPrice.Text = product.Price.ToString();
            shiping.Price = product.Price;
            CalcCost(product);
            costLabel.Text = shiping.Cost.ToString();
        }
        private decimal CalcCost (Product product)
        {
            decimal selectedQuantity = numericUpProdSel.Value;
            shiping.Cost = selectedQuantity * product.Price;
            return shiping.Cost;
        }

        private void numericUpProdSel_ValueChanged(object sender, EventArgs e)
        {
            CalcCost(product);
            costLabel.Text = shiping.Cost.ToString();
        }
    }
}
