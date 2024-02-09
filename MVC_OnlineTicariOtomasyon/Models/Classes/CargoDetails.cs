using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetails
    {
        [Key]
        public int CargoDetailID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Employee { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Customer { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool CargoStatus { get; set; }
    }
}