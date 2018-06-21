using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WOKtch.Factories;
using WOKtch.Models;
using WOKtch.Repositories;

namespace WOKtch.Handlers
{
    public class ReviewHandler
    {
        public static DataTable GetAllByProductId(int ProductId) { return ReviewRepository.GetAllByProductId(ProductId); }
        public static Review GetById(int ReviewId) { return ReviewRepository.GetById(ReviewId); }

        public static void Insert(int ReviewRating, string ReviewText, int ProductId, int UserId)
            { Review u = ReviewFactory.Create(ReviewRating, ReviewText, ProductId, UserId); ReviewRepository.Insert(u); }              // Register
        public static void Delete(int ProductId)
            { ReviewRepository.Delete(ProductId);                                                                       }              // Member  
        public static void Update(int ReviewId, int ReviewRating, string ReviewText)
            { ReviewRepository.Update(ReviewId, ReviewRating, ReviewText);                                                                            }              // Member         
    }
}