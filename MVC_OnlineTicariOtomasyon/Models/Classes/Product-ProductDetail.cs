using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Product_ProductDetail
    {
        public IEnumerable<Product> Products { get; set;}
        public IEnumerable<ProductDetail> ProductDetails { get; set; }
    }
}