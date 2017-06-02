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
    public partial class FrmAddProd : Form
    {
        Product product;
        ProductRepository repo = new ProductRepository();
        public FrmAddProd()
        {
            InitializeComponent();
            product = new Product();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            CopyValueFromControls();
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            repo.AddProduct(product);
        }

        private void CopyValueFromControls()
        {
            if (TxtProdName.Text != null)
                product.ProductName = TxtProdName.Text;

            decimal price;
            if (txtPrice.Text != null)
            {
                decimal.TryParse(txtPrice.Text, out price);
                product.Price = price;
            }

            if (numericUpDownQuant.Value > 0)
            {
                product.Quantity = Convert.ToInt32(numericUpDownQuant.Value);
            }
        }
    }
}
