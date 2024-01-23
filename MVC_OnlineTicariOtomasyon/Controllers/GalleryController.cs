using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineTicariOtomasyon.Models.Classes;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context DbGallery = new Context();
        public ActionResult Index()
        {
            var productImage = (DbGallery.Products.Where(x => x.ProductStatus == true)).ToList();
            return View(productImage);
        }
    }
}