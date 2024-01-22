using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineTicariOtomasyon.Models.Classes;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context DbInvoice=new Context();
        public ActionResult Index()
        {
            var invoices=(DbInvoice.Invoinces.Where(x=>x.InvoinceStatus==true)).ToList();
            return View(invoices);
        }
    }
}