﻿using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}