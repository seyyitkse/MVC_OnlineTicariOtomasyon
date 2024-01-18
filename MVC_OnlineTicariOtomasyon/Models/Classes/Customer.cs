﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; }
        public bool CustomerStatus { get; set; }
        public ICollection<Sales> Sales { get; set; }

    }
}