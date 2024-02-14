using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineTicariOtomasyon.Models.Classes;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context DbInvoice = new Context();
        public List<SelectListItem> employees
        {
            get
            {
                return (from item in DbInvoice.Sales.ToList()
                        select new SelectListItem
                        {
                            Text = item.Employee.EmployeeName + " " + item.Employee.EmployeeSurname,
                            Value = item.EmployeeID.ToString()
                        }).ToList();
            }
        }
        public List<SelectListItem> customers
        {
            get
            {
                return (from item in DbInvoice.Customers.ToList()
                        select new SelectListItem
                        {
                            Text = item.CustomerName + " " + item.CustomerSurname,
                            Value = item.CustomerID.ToString()
                        }).ToList();
            }
        }

        public ActionResult Index()
        {
            var invoices = (DbInvoice.Invoinces.Where(x => x.InvoinceStatus == true)).ToList();
            return View(invoices);
        }
        [HttpGet]
        public ActionResult AddInvoice()
        {
            ViewBag.Employees = employees;
            ViewBag.Customers = customers;
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            DbInvoice.Invoinces.Add(invoice);
            invoice.InvoinceStatus = true;
            invoice.InvoiceSerial = "A";
            invoice.InvoinceDate = DateTime.Now;
            invoice.InvoiceClock = DateTime.Now;
            DbInvoice.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceItemDetails(int id)
        {
            ViewBag.Invoice = id;
            var invoice = DbInvoice.InvoinceItems.Where(x => x.InvoiceID == id).ToList();
            return View(invoice);
        }
        public ActionResult GetInvoice(int id)
        {
            ViewBag.Employees = employees;
            ViewBag.Customers = customers;
            var invoice = DbInvoice.Invoinces.Find(id);
            return View("GetInvoice",invoice);
        }
        public ActionResult UpdateInvoice(Invoice invoices)
        {
            var updated = DbInvoice.Invoinces.Find(invoices.InvoiceID);
            updated.InvoiceSerial = "A";
            updated.InvoiceSequence = invoices.InvoiceSequence;
            updated.InvoiceClock = DateTime.Now;
            updated.InvoinceDate = DateTime.Now;
            updated.InvoiceTax = invoices.InvoiceTax;
            updated.CustomerID = invoices.CustomerID;
            updated.EmployeeID = invoices.EmployeeID;
            DbInvoice.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddInvoiceItem() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem invoiceitem)
        {
            DbInvoice.InvoinceItems.Add(invoiceitem);
            DbInvoice.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DynamicInvoice()
        {
            Dynamic dynamicInvoice=new Dynamic();
            dynamicInvoice.invoices = DbInvoice.Invoinces.ToList();
            dynamicInvoice.invoiceItems=DbInvoice.InvoinceItems.ToList();
            return View(dynamicInvoice);
        }
        public ActionResult AddDynamicInvoice(string InvoiceSerial,string InvoiceSequence,DateTime InvoiveDate,string InvoiceTax,int CustomerID,int EmployeeID,decimal InvoiceTotal,InvoiceItem[] invoiceitems)
        {
            Invoice newDynamicInvoice=new Invoice();
            newDynamicInvoice.InvoiceSerial = InvoiceSerial;
            newDynamicInvoice.InvoiceSequence = InvoiceSequence;
            newDynamicInvoice.InvoinceDate = InvoiveDate;
            newDynamicInvoice.InvoiceTax= InvoiceTax;
            newDynamicInvoice.CustomerID = CustomerID;
            newDynamicInvoice.EmployeeID = EmployeeID;
            newDynamicInvoice.InvoiceTotal= InvoiceTotal;
            DbInvoice.Invoinces.Add(newDynamicInvoice);
            DbInvoice.SaveChanges();
            return Json("Added new Invoice", JsonRequestBehavior.AllowGet);
        }
    }
}