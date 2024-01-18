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
    }
}