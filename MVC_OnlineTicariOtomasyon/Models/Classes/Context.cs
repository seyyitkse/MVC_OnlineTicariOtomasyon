using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invoice> Invoinces { get; set; }
        public DbSet<InvoiceItem> InvoinceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}