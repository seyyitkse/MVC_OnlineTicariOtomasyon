using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context DbCustomer=new Context();
        public ActionResult Index()
        {
            var customers = (DbCustomer.Customers.Where(x => x.CustomerStatus == true)).ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            DbCustomer.Customers.Add(customer);
            customer.CustomerStatus = true;
            DbCustomer.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = DbCustomer.Customers.Find(id);
            customer.CustomerStatus=false;
            DbCustomer.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id) 
        {
            var customer= DbCustomer.Customers.Find(id);
            return View("GetCustomer",customer);
        }
        public ActionResult UpdateCustomer(Customer customer)
        {
            var updatedCustomer = DbCustomer.Customers.Find(customer.CustomerID);
            updatedCustomer.CustomerName = customer.CustomerName;
            updatedCustomer.CustomerSurname= customer.CustomerSurname;
            updatedCustomer.CustomerCity = customer.CustomerCity;
            updatedCustomer.CustomerMail=customer.CustomerMail;
            DbCustomer.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerDetails(int id)
        {
            var customer = DbCustomer.Customers.Find(id);
            ViewBag.customerName = customer.CustomerName + " " + customer.CustomerSurname;
            var customerSales=(DbCustomer.Sales.Where(x=>x.CustomerID==id)).ToList();
            return View(customerSales);
        }
    }
}