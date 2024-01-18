using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context DbDepartment=new Context();
        public ActionResult Index()
        {
            var department=(DbDepartment.Departments.Where(x=>x.DepartmentStatus==true)).ToList();
            return View(department);
        }
    }
}