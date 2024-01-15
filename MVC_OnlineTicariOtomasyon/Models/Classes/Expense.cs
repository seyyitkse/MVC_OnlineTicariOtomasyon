using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ExpenseDescription { get; set; }       
        public DateTime ExpenseDate { get; set; }
        public decimal ExpenseAmount { get; set; }
    }
}