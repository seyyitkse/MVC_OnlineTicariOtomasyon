using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
    }
}