using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class Review
    {
        public int    ReviewId      { get; set; }
        public int    ReviewRating  { get; set; }
        public string ReviewText    { get; set; }
        public int    ProductId     { get; set; }
        public int    UserId        { get; set; }
    }
}