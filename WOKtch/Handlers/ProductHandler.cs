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
    public class ProductHandler
    {
        public static DataTable Get()                   { return ProductRepository.Get();               }
        public static DataTable GetTop(int size)        { return ProductRepository.GetTop(size);        }
        public static Product   GetById(int ProductId)  { return ProductRepository.GetById(ProductId);  }

        public static void Add(string watchName, string watchImage, decimal watchPrice, int quantity)
            { Product p = ProductFactory.Create(watchName, watchImage, watchPrice, quantity); ProductRepository.Add(p);         }
        public static void UpdateWithoutImage(int ProductId, string productName, decimal productPrice, int productQuantity)
            { ProductRepository.Update(ProductId, productName, productPrice, productQuantity);                                  }
        public static void UpdateWithImage(int ProductId, string productName, string productImage, decimal productPrice, int productQuantity)
            { ProductRepository.Update(ProductId, productName, productImage, productPrice, productQuantity);                    }
        public static void Delete(int ProductId)
            {  ProductRepository.Delete(ProductId);                                                                             }
    }
}