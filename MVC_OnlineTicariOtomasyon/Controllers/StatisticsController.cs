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
        Context DbStatistic=new Context();
        public ActionResult Index()
        {
            int customers=DbStatistic.Customers.Count();
            ViewBag.TotalCustomer = customers;

            int products=DbStatistic.Products.Count();
            ViewBag.TotalProduct=products;

            int employees=DbStatistic.Employees.Count();
            ViewBag.TotalEmployee=employees;

            int categories = DbStatistic.Categories.Count();
            ViewBag.TotalCategory= categories;

            var stock = DbStatistic.Products.Sum(x => x.ProductStock);
            ViewBag.TotalStock=stock;

            var brands = (from x in DbStatistic.Products select x.ProductBrand).Distinct().Count();
            ViewBag.TotalBrand=brands;

            var critical = (DbStatistic.Products.Where(x=>x.ProductStock<=20)).Count();
            ViewBag.TotalCritical=critical;

            var price = DbStatistic.Products.Max(x => x.ProductSale);
            ViewBag.MaxPrice=price;

            var minPrice=DbStatistic.Products.Min(x=>x.ProductSale);
            ViewBag.MinPrice=minPrice;

            var fridge = DbStatistic.Products.Count(x => x.ProductName == "Freezer").ToString();
            ViewBag.FridgePiece=fridge;

            var laptop = DbStatistic.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.LaptopPiece=laptop;


            var Cash = DbStatistic.Sales.Sum(x => x.SalesTotalPrice).ToString();
            ViewBag.Cash=Cash;

            DateTime today = DateTime.Today;
            var todaySales = DbStatistic.Sales.Count(x => x.SalesDate == today).ToString();
            ViewBag.TodaySales=todaySales;

            var todayCash = DbStatistic.Sales
                .Where(x => x.SalesDate == today && x.SalesTotalPrice != null)
                .Sum(y => (decimal?)y.SalesTotalPrice) ?? 0;

            ViewBag.TodayCash = todayCash.ToString();

            var maxBrands=DbStatistic.Products.GroupBy(x=>x.ProductBrand).OrderByDescending(z=>z.Count()).Select(x=>x.Key).FirstOrDefault();
            ViewBag.MaxBrands=maxBrands;

            return View();
        }
        public ActionResult SimpleTables() 
        { 
            return View(); 
        }
    }
}