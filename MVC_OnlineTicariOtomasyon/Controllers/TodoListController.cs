using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineTicariOtomasyon.Models.Classes;
namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class TodoListController : Controller
    {
        Context DbTodo=new Context();
        public ActionResult Index()
        {
            var sales = DbTodo.Sales.Count();
            ViewBag.Sales = sales;

            var customers=DbTodo.Customers.Count();
            ViewBag.Customers = customers;

            var products=DbTodo.Products.Count();
            ViewBag.Products = products;

            var cities=(from x in DbTodo.Customers select x.CustomerCity).Distinct().Count();
            ViewBag.Cities = cities;

            var todo=(DbTodo.TodoLists.Where(x=>x.ToDoStatus==false)).ToList();
            return View(todo);
        }
    }
}