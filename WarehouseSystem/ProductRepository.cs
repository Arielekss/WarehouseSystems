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
        Product prod = new Product();
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

        public List<Product> GetProductList()
        {
            connection.Open();
                sqlCommand = string.Format("Select Id, ProductName, Price, Quantity from Product;");
                command = new SQLiteCommand(sqlCommand, connection);
                command.ExecuteNonQuery();
                DataSet ds = new DataSet();
                var adapter = new SQLiteDataAdapter(sqlCommand, connection);
                adapter.Fill(ds);
            connection.Close();
            List<Product> prodList = new List<Product>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                prodList.Add(new Product
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Price = Convert.ToDecimal(dr["Price"]),
                    Quantity = Convert.ToInt32(dr["Quantity"])
                });
            }
            return prodList;
        }
        
        public void AddUser(Users user)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                sqlCommand = string.Format("Insert into user (username, password) VALUES ('{0}', '{1}');", user.Username, user.Password);
                command = new SQLiteCommand(sqlCommand, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Account created!");
            }
            connection.Close();
        }
    }
}
