using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context DbLogin=new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer newCustomer)
        {
            DbLogin.Customers.Add(newCustomer);
            newCustomer.CustomerStatus = true;
            DbLogin.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var info = DbLogin.Customers.FirstOrDefault(x => x.CustomerMail == customer.CustomerMail && x.CustomerPassword == customer.CustomerPassword);
            if (info != null) 
            {
                FormsAuthentication.SetAuthCookie(info.CustomerMail, false);
                Session["CustomerMail"] = info.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}