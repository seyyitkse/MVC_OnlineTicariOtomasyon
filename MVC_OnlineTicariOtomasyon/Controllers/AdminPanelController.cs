using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        Context DbAdmin=new Context();
        public ActionResult Index()
        {
            var user = (string)Session["AdminUsername"];
            var id = DbAdmin.Admins.Where(x => x.AdminUsername == user).Select(y => y.AdminID).FirstOrDefault();
            var admin = DbAdmin.Employees.Where(x => x.EmployeeID == id).Select(y=>y.EmployeeName+" "+y.EmployeeSurname).FirstOrDefault();
            ViewBag.name = admin;
            var values = DbAdmin.Admins.FirstOrDefault(x => x.AdminUsername == user);
            ViewBag.CustomerMail = user;
            return View(values);
        }
        public ActionResult UpdateInfo(Admin admin)
        {
            var updatedAdmin = DbAdmin.Admins.Find(admin.AdminID);
            updatedAdmin.AdminPassword = admin.AdminPassword;
            DbAdmin.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}