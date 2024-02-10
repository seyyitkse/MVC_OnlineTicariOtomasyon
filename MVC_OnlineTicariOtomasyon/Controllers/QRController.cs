using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms=new MemoryStream())
            {
                QRCodeGenerator newCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode newcode = newCode.CreateQrCode(code,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = newcode.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.QRCode = "data:image/png;base64"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}