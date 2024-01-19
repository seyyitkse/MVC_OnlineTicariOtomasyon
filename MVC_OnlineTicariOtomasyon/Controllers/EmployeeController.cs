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

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> departments=(from item in DbEmployee.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text=item.DepartmentName,
                                                  Value=item.DepartmentID.ToString(),
                                              }).ToList();
            ViewBag.departmentsName = departments;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            DbEmployee.Employees.Add(employee);
            employee.EmployeeStatus = true;
            DbEmployee.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id) 
        {
            var employee = DbEmployee.Employees.Find(id);
            employee.EmployeeStatus=false;
            DbEmployee.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}