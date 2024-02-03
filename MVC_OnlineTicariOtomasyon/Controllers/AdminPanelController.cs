using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        Context DbAdmin=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var user = (string)Session["AdminUsername"];
            var values = DbAdmin.Admins.FirstOrDefault(x => x.AdminUsername == user);
            ViewBag.CustomerMail = user;
            return View(values);
        }
    }
}