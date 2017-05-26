using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSystem
{
    public class ProductRepository
    {
        SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "WarehouseDB.sqlite")));
        SQLiteCommand command;
        string sqlCommand;
        
        public void AddProduct(Product product)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                sqlCommand = string.Format("Insert into Product (ProductName, Price, Quantity) VALUES ('{0}', {1},{2});", product.ProductName, product.Price, product.Quantity);
                command = new SQLiteCommand(sqlCommand, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Product Added");
            }
            connection.Close();
        }

        public object GetProductData()
        {
            connection.Open();
                sqlCommand = string.Format("Select Id, ProductName, Price, Quantity from Product;");
                command = new SQLiteCommand(sqlCommand, connection);
                command.ExecuteNonQuery();
                DataSet ds = new DataSet();
                var adapter = new SQLiteDataAdapter(sqlCommand, connection);
                adapter.Fill(ds);
            connection.Close();
            return ds.Tables[0].DefaultView;
        }
    }
}
