using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context DbCustomerPanel=new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var values=DbCustomerPanel.Customers.FirstOrDefault(x=>x.CustomerMail == mail);
            ViewBag.CustomerMail = mail;
            return View(values);
        }
        public ActionResult UpdateInfo(Customer customer)
        {
            var updatedCustomer = DbCustomerPanel.Customers.Find(customer.CustomerID);
            updatedCustomer.CustomerName = customer.CustomerName;
            updatedCustomer.CustomerSurname = customer.CustomerSurname;
            updatedCustomer.CustomerCity = customer.CustomerCity;
            updatedCustomer.CustomerPassword = customer.CustomerPassword;
            DbCustomerPanel.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerOrders()
        {
            var mail = (string)Session["CustomerMail"];
            var customerid=DbCustomerPanel.Customers.Where(x=>x.CustomerMail==mail).Select(y=>y.CustomerID).FirstOrDefault();
            var orders=(DbCustomerPanel.Sales.Where(x=>x.CustomerID==customerid)).ToList();
            return View(orders);
        }
    }
}