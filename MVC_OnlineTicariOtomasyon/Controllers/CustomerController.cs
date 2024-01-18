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
    }
}