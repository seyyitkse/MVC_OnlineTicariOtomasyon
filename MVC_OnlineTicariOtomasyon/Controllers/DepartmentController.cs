using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles ="B")]
    public class DepartmentController : Controller
    {
        Context DbDepartment=new Context();
        
        public ActionResult Index()
        {
            var department=(DbDepartment.Departments.Where(x=>x.DepartmentStatus==true)).ToList();
            return View(department);
        }

        [HttpGet]
        public ActionResult AddDepartment() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            DbDepartment.Departments.Add(department);
            department.DepartmentStatus = true;
            DbDepartment.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id) 
        {
            var department = DbDepartment.Departments.Find(id);
            department.DepartmentStatus=false;
            DbDepartment.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var department = DbDepartment.Departments.Find(id);
            return View("GetDepartment",department);
        }
        public ActionResult UpdateDepartment(Department department) 
        {
            var updated = DbDepartment.Departments.Find(department.DepartmentID);
            updated.DepartmentName=department.DepartmentName;
            DbDepartment.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetails(int id)
        {
            var department = DbDepartment.Departments.Find(id);
            ViewBag.departmentName=department.DepartmentName;
            var employee=(DbDepartment.Employees.Where(x=>x.DepartmentID==id)).ToList();
            return View(employee);
        }
        public ActionResult DepartmentEmployeeSales(int id)
        {
            var employee= DbDepartment.Employees.Find(id);
            ViewBag.employeeName=employee.EmployeeName+" "+employee.EmployeeSurname;
            var sales = (DbDepartment.Sales.Where(x => x.EmployeeID == id)).ToList();
            return View(sales);
        }
    }
}