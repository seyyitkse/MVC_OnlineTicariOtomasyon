using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    { 
        Context DbCategories=new Context();
        public ActionResult Index()
        {
            var category=(DbCategories.Categories.Where(x=>x.CategoryStatus==true)).ToList();
            return View(category);
        }
    }
}