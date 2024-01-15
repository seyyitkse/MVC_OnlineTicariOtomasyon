using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Invoince
    {
        [Key]
        public int InvoinceID { get; set; }


        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoinceSerial { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoinceSequence { get; set; }
        public DateTime InvoinceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string InvoinceTax { get; set; }
        public DateTime InvoinceClock { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoinceDeliverer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoinceAcceptor { get; set; }
        public bool InvoinceStatus { get; set;}
        public ICollection<InvoinceItem> InvoinceItems { get; set; }
    }
}