using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.Factories
{
    public class ProductFactory
    {
        public static Product Create(string watchName, string watchImage, decimal watchPrice, int watchQuantity)
        {
            Product p = new Product();
            p.ProductName = watchName;
            p.ProductPrice = watchPrice;
            p.ProductImage = watchImage;
            p.ProductStock = watchQuantity;
            return p;
        }
    }
}