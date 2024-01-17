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
    }
}