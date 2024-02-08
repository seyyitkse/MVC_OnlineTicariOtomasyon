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
        public List<SelectListItem> employee
        {
            get
            {
                return (from item in DbProduct.Employees.ToList()
                        select new SelectListItem
                        {
                            Text = item.EmployeeName + " " + item.EmployeeSurname,
                            Value = item.EmployeeID.ToString()
                        }).ToList();
            }
        }
        public List<SelectListItem> customer
        {
            get
            {
                return (from item in DbProduct.Customers.ToList()
                        select new SelectListItem
                        {
                            Text = item.CustomerName + " " + item.CustomerSurname,
                            Value = item.CustomerID.ToString()
                        }).ToList();
            }
        }

        
        public ActionResult Index(string search)
        {
            //var product=(DbProduct.Products.Where(x=>x.ProductStatus==true)).ToList();
            var product = from x in DbProduct.Products select x;
            if (!string.IsNullOrEmpty(search))
            {
                product=product.Where(y=>y.ProductName.Contains(search));
            }
            return View(product.ToList());
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
            updated.ProductImage = product.ProductImage;
            updated.CategoryID = product.CategoryID;
            DbProduct.SaveChanges();
            return RedirectToAction("Index");
        }
        Product_ProductDetail newDetails= new Product_ProductDetail();
        public ActionResult ProductDetails()
        {
            newDetails.Products = DbProduct.Products.ToList();
            newDetails.ProductDetails= DbProduct.Details.ToList();
            return View(newDetails);
        }
        [HttpGet]
        public ActionResult MakeSale(int id)
        {
            ViewBag.employee = employee;
            ViewBag.customer = customer;
            var product=DbProduct.Products.Find(id);
            ViewBag.Product=product.ProductID;
            ViewBag.Sale = product.ProductSale;
            ViewBag.Quantity = product.ProductStock;
            return View();
        }
        [HttpPost]
        public ActionResult MakeSale(Sales newSale)
        {
            newSale.SalesDate=DateTime.Now;
            DbProduct.Sales.Add(newSale);
            MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction trigger = new MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction();

            trigger.PerformTrigger(newSale.ProductID, newSale.SalesQuantity);
            DbProduct.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}