﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class Product
    {
        public int     ProductId          { get; set; }
        public string  ProductName        { get; set; }
        public string  ProductImage       { get; set; }
        public decimal ProductPrice       { get; set; }
        public int     ProductStock       { get; set; }
    }
}