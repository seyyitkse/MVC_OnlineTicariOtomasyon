using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }


        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerial { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSequence { get; set; }
        public DateTime InvoinceDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string InvoiceTax { get; set; }
        public DateTime InvoiceClock { get; set; }
        public bool InvoinceStatus { get; set;}
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}