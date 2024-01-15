using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public bool EmployeeStatus { get; set; }
        public ICollection<Sales> Sales { get; set; }

        public Department Department { get; set; }
    }
}