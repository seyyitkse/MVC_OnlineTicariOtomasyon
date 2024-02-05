using MVC_OnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;
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
        public ActionResult Index(int page=1)
        {
            var category=(DbCategories.Categories.Where(x=>x.CategoryStatus==true)).ToList().ToPagedList(page,3);
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
   

        public ActionResult GetCategory(int id) 
        {
            var category=DbCategories.Categories.Find(id);
            return View("GetCategory",category);
        }
        public ActionResult UpdateCategory(Category update) 
        {
            var category = DbCategories.Categories.Find(update.CategoryID);
            category.CategoryName = update.CategoryName;
            DbCategories.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}