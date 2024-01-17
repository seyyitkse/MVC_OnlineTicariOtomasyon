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
        public List<SelectListItem> Categories
        {
            get
            {
                return (from item in DbProduct.Categories.ToList()
                        select new SelectListItem
                        {
                            Text = item.CategoryName,
                            Value = item.CategoryID.ToString()
                        }).ToList();
            }
        }

        public ActionResult Index()
        {
            var product=(DbProduct.Products.Where(x=>x.ProductStatus==true)).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = Categories;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product) 
        {
            DbProduct.Products.Add(product);
            product.ProductStatus = true;
            DbProduct.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id) 
        {
            var product = DbProduct.Products.Find(id);
            product.ProductStatus=false;
            DbProduct.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id) 
        {
            ViewBag.ProductCategory = Categories;
            var product = DbProduct.Products.Find(id);
            return View("GetProduct",product); 
        }

        public ActionResult UpdateProduct(Product product)
        {
            var updated=DbProduct.Products.Find(product.ProductID);
            updated.ProductName = product.ProductName;
            updated.ProductBrand = product.ProductBrand;
            updated.ProductSale = product.ProductSale;
            updated.ProductStock = product.ProductStock;
            updated.ProductPurchase = product.ProductPurchase;
            updated.CategoryID = product.CategoryID;
            DbProduct.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}