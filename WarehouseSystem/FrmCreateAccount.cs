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
    public partial class FrmCreateAccount : Form
    {
        Users user = new Users();
        ProductRepository repo = new ProductRepository();
        public FrmCreateAccount()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            CopyValueFromControls();

            if(user.Username==null)
            {
                MessageBox.Show("UserName is not provide");
                return;
            }
            repo.AddUser(user);
        }

        private void CopyValueFromControls()
        {
           if(txtCUsername.Text != "")
            {
                user.Username = txtCUsername.Text;
            }

           if(txtCPass.Text != "")
            {
                user.Password = txtCPass.Text;
            }
        }
    }
}
