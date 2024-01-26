using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetail
    {
        [Key]
        public int DetailID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string ProductDescription { get; set; }
        public decimal ProductScore { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product{ get; set; }
    }
}