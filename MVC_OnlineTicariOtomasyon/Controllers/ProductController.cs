using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context DbProduct=new Context();
        public ActionResult Index()
        {
            var product=(DbProduct.Products.Where(x=>x.ProductStatus==true)).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product) 
        {
            DbProduct.Products.Add(product);
            product.ProductStatus = true;
            product.Category.CategoryID = 1;
            DbProduct.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}