﻿using MVC_OnlineTicariOtomasyon.Models.Classes;
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
            DbSales.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}