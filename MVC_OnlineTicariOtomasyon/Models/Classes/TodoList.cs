using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class TodoList
    {
        [Key]
        public int ToDoID  { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title  { get; set; }
        public bool ToDoStatus { get; set; }
    }
}