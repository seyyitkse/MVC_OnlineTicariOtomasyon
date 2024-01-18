using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Sales
    {
        [Key]
        public int SalesID { get; set; }
        public DateTime SalesDate { get; set; }
        public int SalesQuantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesTotalPrice { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}