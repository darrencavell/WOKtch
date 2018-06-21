using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.Factories
{
    public class ReviewFactory
    {
        public static Review Create(int ReviewRating, string ReviewText, int ProductId, int UserId)
        {
            Review r = new Review();
            r.ReviewRating = ReviewRating;
            r.ReviewText = ReviewText;
            r.ProductId = ProductId;
            r.UserId = UserId;
            return r;
        }
    }
}