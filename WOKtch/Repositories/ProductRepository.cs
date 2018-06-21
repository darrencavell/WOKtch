using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using WOKtch.Factories;
using WOKtch.Models;
using WOKtch.Utilities;

namespace WOKtch.Repositories
{
    public class ProductRepository
    {
        public static DataTable Get()
        {
            string query = string.Format("SELECT * FROM [Product]");

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            return dt;
        }
        public static DataTable GetTop(int size)
        {
            string query = string.Format("SELECT TOP {0} * FROM [Product] ORDER BY ProductStock DESC", size);

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            return dt;
        }
        public static Product GetById(int ProductId)
        {
            string query = string.Format("SELECT * FROM [Product] WHERE (ProductId) = {0}", ProductId);

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            Product u = null;
            foreach(DataRow x in dt.Rows)
            {
                u = ProductFactory.Create(x["ProductName"].ToString(), 
                                            x["ProductImage"].ToString(), 
                                            Convert.ToDecimal(x["ProductPrice"]), 
                                            Int32.Parse(x["ProductStock"].ToString()));
            }
            return u;
        }
        public static void Add(Product p)
        {
            string query = string.Format("INSERT INTO [Product](ProductName, ProductImage, ProductPrice, ProductStock) VALUES('{0}', '{1}', {2}, {3})", p.ProductName, p.ProductImage, p.ProductPrice, p.ProductStock);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        public static void Update(int ProductId, string productName, decimal productPrice, int productQuantity)
        {
            string query = string.Format("UPDATE [Product] SET ProductName = '{0}', ProductPrice = {1}, ProductStock = {2} WHERE ProductId = {3}", productName, productPrice, productQuantity, ProductId);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        public static void Update(int ProductId, string productName, string productImage, decimal productPrice, int productQuantity)
        {
            string query = "UPDATE [Product] SET ProductName = '" + productName + "', ProductImage = '" + productImage + "', ProductPrice = '" + productPrice + "', ProductStock = '" + productQuantity + "' WHERE ProductId = " + ProductId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
        public static void Delete(int ProductId)
        {
            string query = "DELETE [Product] WHERE ProductId = " + ProductId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
    }
}