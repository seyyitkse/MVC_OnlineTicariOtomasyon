using Microsoft.SqlServer.Server;
using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context DbSales = new Context();

        public List<SelectListItem> employees
        {
            get
            {
                return (from item in DbSales.Sales.ToList()
                        select new SelectListItem
                        {
                            Text = item.Employee.EmployeeName + " " + item.Employee.EmployeeSurname,
                            Value = item.EmployeeID.ToString()
                        }).ToList();
            }
        }
        public List<SelectListItem> customers
        {
            get
            {
                return (from item in DbSales.Customers.ToList()
                        select new SelectListItem
                        {
                            Text = item.CustomerName + " " + item.CustomerSurname,
                            Value = item.CustomerID.ToString()
                        }).ToList();
            }
        }

        public List<SelectListItem> products
        {
            get
            {
                return (from item in DbSales.Products.ToList()
                        select new SelectListItem
                        {
                            Text = item.ProductName +"("+item.ProductBrand+")",
                            Value = item.ProductID.ToString()
                        }).ToList();
            }
        }
        public ActionResult Index()
        {
            var sales = DbSales.Sales.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            ViewBag.Employees = employees;
            ViewBag.Customers=customers;
            ViewBag.Products=products;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(Sales sales)
        {
            DbSales.Sales.Add(sales);
            sales.SalesTotalPrice = sales.SalesPrice * sales.SalesQuantity;
            sales.SalesDate= DateTime.Now;
            MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction trigger = new MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction();

            trigger.PerformTrigger(sales.ProductID, sales.SalesQuantity);
            DbSales.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSale(int id) 
        {
            ViewBag.Employees = employees;
            ViewBag.Customers = customers;
            ViewBag.Products = products;
            var sale=DbSales.Sales.Find(id);
            return View("GetSale",sale);
        }
        public ActionResult UpdateSale(Sales sales) 
        {
            var updated = DbSales.Sales.Find(sales.SalesID);
            updated.CustomerID= sales.CustomerID;
            updated.EmployeeID=sales.EmployeeID;
            updated.ProductID=sales.ProductID;
            updated.SalesPrice = sales.SalesPrice;
            updated.SalesQuantity = sales.SalesQuantity;
            updated.SalesTotalPrice = sales.SalesPrice * sales.SalesQuantity;
            updated.SalesDate = DateTime.Now;
            MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction trigger = new MVC_OnlineTicariOtomasyon.Models.Trigger.TriggerAction();

            trigger.PerformTrigger(sales.ProductID, sales.SalesQuantity);
            DbSales.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetails(int id)
        {
            ViewBag.SaleID = id;
            var sale = (DbSales.Sales.Where(x => x.SalesID == id)).ToList();
            return View(sale);
        }
        public ActionResult PrintSale(int id) 
        {
            var sale = (DbSales.Sales.Where(x => x.SalesID == id)).ToList();
            return View(sale);
        }
    }
}