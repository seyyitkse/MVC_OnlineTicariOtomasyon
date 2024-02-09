using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        public bool CargoStatus { get; set; }
    }
}