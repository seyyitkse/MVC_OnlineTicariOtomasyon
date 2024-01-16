using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category newcategory)
        {
            DbCategories.Categories.Add(newcategory);
            newcategory.CategoryStatus = true;
            DbCategories.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id) 
        {
            var delete=DbCategories.Categories.Find(id);
            delete.CategoryStatus = false;
            DbCategories.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}