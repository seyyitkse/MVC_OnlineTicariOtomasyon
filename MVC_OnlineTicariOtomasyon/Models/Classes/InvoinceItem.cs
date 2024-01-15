using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class InvoinceItem
    {
        [Key]
        public int InvoinceItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoinceItemDescription { get;set; }
        public int InvoinceItemPiece { get; set; }
        public decimal InvoinceItemUnitPrice { get; set; }
        public decimal InvoinceItemAmount { get; set; }
        public bool InvoinceItemStatus { get; set; }
        public Invoince Invoince { get; set; }
    }
}