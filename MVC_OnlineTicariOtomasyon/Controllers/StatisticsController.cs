using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineTicariOtomasyon.Models.Classes;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context DbStatistic = new Context();
        public ActionResult Index()
        {
            int customers = DbStatistic.Customers.Count();
            ViewBag.TotalCustomer = customers;

            int products = DbStatistic.Products.Count();
            ViewBag.TotalProduct = products;

            int employees = DbStatistic.Employees.Count();
            ViewBag.TotalEmployee = employees;

            int categories = DbStatistic.Categories.Count();
            ViewBag.TotalCategory = categories;

            var stock = DbStatistic.Products.Sum(x => x.ProductStock);
            ViewBag.TotalStock = stock;

            var brands = (from x in DbStatistic.Products select x.ProductBrand).Distinct().Count();
            ViewBag.TotalBrand = brands;

            var critical = (DbStatistic.Products.Where(x => x.ProductStock <= 20)).Count();
            ViewBag.TotalCritical = critical;

            var price = DbStatistic.Products.Max(x => x.ProductSale);
            ViewBag.MaxPrice = price;

            var minPrice = DbStatistic.Products.Min(x => x.ProductSale);
            ViewBag.MinPrice = minPrice;

            var fridge = DbStatistic.Products.Count(x => x.ProductName == "Freezer").ToString();
            ViewBag.FridgePiece = fridge;

            var laptop = DbStatistic.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.LaptopPiece = laptop;


            var Cash = DbStatistic.Sales.Sum(x => x.SalesTotalPrice).ToString();
            ViewBag.Cash = Cash;

            DateTime today = DateTime.Now.Date;
            var todaySales = DbStatistic.Sales.Count(x => x.SalesDate == today).ToString();
            ViewBag.TodaySales = todaySales;

            var todayCash = DbStatistic.Sales
                .Where(x => x.SalesDate == today)
                .Sum(y => (decimal?)y.SalesTotalPrice).ToString();
            ViewBag.TodayCash = todayCash.ToString();

            var maxBrands = DbStatistic.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.MaxBrands = maxBrands;

            return View();
        }
        public ActionResult SimpleTables()
        {
            var table = from x in DbStatistic.Customers
                        group x by x.CustomerCity into query
                        select new GroupCustomer
                        {
                            Town = query.Key,
                            CustomerNumber = query.Count()
                        };
            return View(table.ToList());
        }

        public PartialViewResult Partial1()
        {
            var table2 =from x in DbStatistic.Employees
                        group x by x.Department.DepartmentName into query2 
                        select new GroupEmployee
                        {
                            DepartmentName = query2.Key,
                            Number = query2.Count()
                        };
            return PartialView(table2.ToList());
        }
        public PartialViewResult Partial2() 
        {
            var customers = (DbStatistic.Customers.Where(x=>x.CustomerStatus==true)).ToList();
            return PartialView(customers);
        }
        public PartialViewResult Partial3()
        {
            var products = (DbStatistic.Products.Where(x=>x.ProductStatus==true)).ToList();
            return PartialView(products);
        }
        public PartialViewResult Partial4()
        {
            var table3 = from x in DbStatistic.Products
                        group x by x.ProductBrand into query
                        select new GroupBrand
                        {
                            BrandName = query.Key,
                            Count = query.Count()
                        };
             return PartialView(table3.ToList());
        }
    }
}