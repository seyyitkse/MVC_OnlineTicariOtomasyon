using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context DbEmployee = new Context(); 
        public ActionResult Index() 
        { 
            var employee = (DbEmployee.Employees.Where(x => x.EmployeeStatus == true)).ToList(); 
            return View(employee); 
        }
    }
}