using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Classes
{
    public class Dynamic
    {
        public IEnumerable<Invoice> invoices { get; set; }
        public IEnumerable<InvoiceItem> invoiceItems { get; set; }
    }
}