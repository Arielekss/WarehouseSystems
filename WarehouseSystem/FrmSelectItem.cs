using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WarehouseSystem
{
    public partial class FrmSelectItem : Form
    {
        Product product = new Product();
        Shipping shiping = new Shipping();
        List<Shipping> prodList = new List<Shipping>();
        ProductRepository repo = new ProductRepository();

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
        private decimal CalcCost(Product product)
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
            {
                repo.AddShipping(shiping);
                
                /* try
                 {
                     MailMessage mail = new MailMessage();
                     SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                     mail.From = new MailAddress("csharptestowe@gmail.com");
                     mail.To.Add("csharptestowe@gmail.com");
                     mail.Subject = "Twoje zamówienie z WorkFlowShop";
                     mail.Body = string.Format("Dziękujemy za zakup w naszym sklepie. Koszt Twojego koszyka to {0}", shiping.Cost);
                     //csharptestowe@gmail.com 
                     SmtpServer.Port = 587;
                     SmtpServer.Credentials = new System.Net.NetworkCredential("csharptestowe@gmail.com", "x");
                     SmtpServer.EnableSsl = true;

                     SmtpServer.Send(mail);
                     MessageBox.Show("mail Send");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }*/
            }
        }
    }
}
    

