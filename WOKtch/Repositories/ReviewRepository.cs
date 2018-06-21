using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WOKtch.Models;
using WOKtch.Utilities;

namespace WOKtch.Repositories
{
    public class ReviewRepository
    {
        public static DataTable GetAllByProductId(int ProductId)
        {
            string query = string.Format("SELECT * FROM [Review] WHERE (ProductId) = {0}", ProductId);

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            return dt;
        }

        public static void Insert(Review r)
        {
            string query = string.Format("INSERT INTO [Review](ReviewRating, ReviewText, ProductId, UserId) VALUES({0}, '{1}', {2}, {3})", r.ReviewRating, r.ReviewText, r.ProductId, r.UserId);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        /**/
        public static void Update(int ProductId, string productName, decimal productPrice)
        {
            string query = "UPDATE [Product] SET ProductName = '" + productName + "', ProductPrice = " + productPrice + " WHERE ProductId = " + ProductId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
        public static void Update(int ProductId, string productName, string productImage, decimal productPrice)
        {
            string query = "UPDATE [Product] SET ProductName = '" + productName + "', ProductImage = '" + productImage + "', ProductPrice = " + productPrice + " WHERE ProductId = " + ProductId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
        /**/
        public static void Delete(int ProductId)
        {
            string query = "DELETE [Review] WHERE ProductId = " + ProductId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
    }
}