using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

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
        public void MessageCount()
        {
            var mail = (string)Session["CustomerMail"];
            var incomingMessage = DbCustomerPanel.Messages.Count(x => x.Receiver == mail).ToString();
            var outgoingMessage = DbCustomerPanel.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.outgoing = outgoingMessage;
            ViewBag.incoming = incomingMessage;
        }
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CustomerMail"];   
            var message = DbCustomerPanel.Messages.Where(x => x.Receiver == mail).OrderByDescending(x=>x.MessageID).ToList();
            MessageCount();
            return View(message);
        }
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CustomerMail"];
            var message = DbCustomerPanel.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageID).ToList();
            MessageCount();
            return View(message);
        }
      
        public ActionResult MessageDetails(int? id)
        {
            var details=DbCustomerPanel.Messages.Where(x=>x.MessageID==id).ToList();    
            var mail = (string)Session["CustomerMail"];
            MessageCount();
            return View(details);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.Sender = (string)Session["CustomerMail"];
            message.Date = DateTime.Now;
            DbCustomerPanel.Messages.Add(message);
            DbCustomerPanel.SaveChanges();
            return RedirectToAction("IncomingMessages");
        }
        public PartialViewResult mailSection()
        {
            MessageCount();
            return PartialView();
        }
        public ActionResult MyCargo()
        {
            var mail = (string)Session["CustomerMail"];
            var customer = DbCustomerPanel.Customers.FirstOrDefault(x => x.CustomerMail == mail);
            var fullName = $"{customer.CustomerName } {customer.CustomerSurname} ";

            var cargo = DbCustomerPanel.CargoDetails.Where(y => y.Customer == fullName).ToList();
            //var cargo=DbCustomerPanel.CargoDetails.ToList();
            return View(cargo);
        }
        public ActionResult MyCargoDetails(string id)
        {
            var details = DbCustomerPanel.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(details);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}