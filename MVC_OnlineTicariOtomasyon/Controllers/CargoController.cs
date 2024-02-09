using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context DbCargo=new Context();
        public ActionResult Index(string searchcargo)
        {
            var product = from x in DbCargo.CargoDetails select x;
            if (!string.IsNullOrEmpty(searchcargo))
            {
                product = product.Where(y => y.TrackingCode.Contains(searchcargo));
            }
            return View(product.ToList());
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            Random rnd = new Random();

            int number1, number2, number3, number4, number5;

            int letter1, letter2, letter3, letter4;

            number1 = rnd.Next(1, 9);

            number2 = rnd.Next(0, 9);

            number3 = rnd.Next(0, 9);

            number4 = rnd.Next(1, 9);

            letter1 = rnd.Next(65, 91);

            number5 = rnd.Next(65, 91);

            letter2 = rnd.Next(65, 91);

            letter3 = rnd.Next(65, 91);

            letter4 = rnd.Next(65, 91);

            if (letter1 == letter2)
            {
                letter2 = rnd.Next(65, 91);
            }

            if (letter2 == letter3)
            {
                letter3 = rnd.Next(65, 91);
            }

            if (letter3 == letter4)
            {
                letter4 = rnd.Next(65, 91);
            }

            if (number1 == number2)
            {
                number2 = rnd.Next(1, 9);
            }

            if (number2 == number3)
            {
                number3 = rnd.Next(0, 9);
            }

            if (number3 == number4)
            {
                number4 = rnd.Next(1, 9);
            }

            if (number4 == number5)
            {
                number5 = rnd.Next(0, 9);
            }

            char character1, character2, character3, character4;

            character1 = Convert.ToChar(letter1);

            character2 = Convert.ToChar(letter2);

            character3 = Convert.ToChar(letter3);

            character4 = Convert.ToChar(letter4);

            string code = number1.ToString() + number2.ToString() + character1 + number3.ToString() + number4.ToString() + character2 + number4.ToString() + character3 + number5.ToString() + character4;

            ViewBag.tracking = code;
            return View();
        }
        [HttpPost]
        public ActionResult NewCargo(CargoDetails cargoDetails)
        {
            DbCargo.CargoDetails.Add(cargoDetails);
            cargoDetails.CargoStatus = true;
            DbCargo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var details=DbCargo.CargoTrackings.Where(x=>x.TrackingCode==id).ToList();
            return View(details);
        }
    }
}