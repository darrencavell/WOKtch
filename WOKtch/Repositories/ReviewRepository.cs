using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WOKtch.Factories;
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

        public static Review GetById(int ReviewId)
        {
            string query = string.Format("SELECT * FROM [Review] WHERE (ReviewId) = {0}", ReviewId);

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            Review u = null;
            foreach (DataRow x in dt.Rows)
            {
                u = ReviewFactory.Create(Int32.Parse(x["ReviewRating"].ToString()),
                                            x["ReviewText"].ToString(),
                                            Int32.Parse(x["ProductId"].ToString()),
                                            Int32.Parse(x["UserId"].ToString()));
            }
            return u;
        }

        public static void Insert(Review r)
        {
            string query = string.Format("INSERT INTO [Review](ReviewRating, ReviewText, ProductId, UserId) VALUES({0}, '{1}', {2}, {3})", r.ReviewRating, r.ReviewText, r.ProductId, r.UserId);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        
        public static void Update(int ReviewId, int reviewRating, string reviewText)
        {
            string query = "UPDATE [Review] SET ReviewRating = '" + reviewRating + "', ReviewText = '" + reviewText + "' WHERE ReviewId = " + ReviewId;
            DatabaseConnection.ExecuteNonQuery(query);
        }

        //public static void Update(int ProductId, string productName, string productImage, decimal productPrice)
        //{
        //    string query = "UPDATE [Product] SET ProductName = '" + productName + "', ProductImage = '" + productImage + "', ProductPrice = " + productPrice + " WHERE ProductId = " + ProductId;
        //    DatabaseConnection.ExecuteNonQuery(query);
        //}
        
        public static void Delete(int ReviewId)
        {
            string query = "DELETE [Review] WHERE ReviewId = " + ReviewId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
    }
}