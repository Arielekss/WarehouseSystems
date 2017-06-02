using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSystem.GUI
{
    public partial class FrmSelectItem : Form
    {
        Product prod = new Product();
        public FrmSelectItem()
        {
            InitializeComponent();
        }

        public FrmSelectItem(Product product)
        {
            InitializeComponent();
            this.prod = product;
        }
    }
}
