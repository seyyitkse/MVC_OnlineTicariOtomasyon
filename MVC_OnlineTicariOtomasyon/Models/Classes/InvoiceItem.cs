using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceItemDescription { get;set; }
        public int InvoiceItemPiece { get; set; }
        public decimal InvoiceItemUnitPrice { get; set; }
        public decimal InvoiceItemAmount { get; set; }
        public bool InvoiceItemStatus { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}