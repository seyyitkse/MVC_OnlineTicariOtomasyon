using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }


        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        public string ProductPurschase { get; set; }
        public string ProductSale { get; set; }
        public bool ProductCritical { get; set; }
        public bool ProductStatus { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public Category Category { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}