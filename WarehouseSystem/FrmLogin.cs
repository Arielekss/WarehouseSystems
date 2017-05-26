using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSystem
{
    public partial class FrmLogin : Form
    {
        Product product = new Product();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "WarehouseDB.sqlite")));
            SQLiteCommand command;
            string sqlCommand;

            if (txtLogin.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }

            try
            {
                connection.Open();
                sqlCommand = string.Format("select * from user where username='{0}' and password='{1}';", txtLogin.Text, txtPassword.Text);
                command = new SQLiteCommand(sqlCommand, connection);
                SQLiteDataAdapter adapt = new SQLiteDataAdapter(command);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                connection.Close();
                int count = ds.Tables[0].Rows.Count;

                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    using (FrmMain frm = new FrmMain())
                        frm.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FrmCreateAccount frm = new FrmCreateAccount())
                frm.ShowDialog(this);
        }
    }
}
