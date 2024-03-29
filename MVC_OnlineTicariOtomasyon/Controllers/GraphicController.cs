﻿using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC_OnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        Context DbGraphic = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Graphic() 
        {
            var newGraphic = new Chart(600, 600);
            newGraphic.AddTitle("Category-Product Quantity").AddLegend("Stock").AddSeries("Values", xValue: new[] { "Furniture", "Office Furniture", "Computer" }, yValues: new[] {85,66,98}).Write();
            return File(newGraphic.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult DatabaseGraph()
        {
            ArrayList xvalue=new ArrayList();
            ArrayList yvalue=new ArrayList();
            var results = DbGraphic.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.ProductStock));
            var graph = new Chart(600, 600).AddTitle("Stocks")
                .AddSeries(chartType: "Area", name: "Stock", xValue: xvalue, yValues: yvalue);
            return File(graph.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult GoogleChart()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(),JsonRequestBehavior.AllowGet);
        }
        public List<GoogleChart> ProductList() 
        {
            List<GoogleChart> newClass1=new List<GoogleChart>();
            using (Context Graphic = new Context())
            {
                newClass1=Graphic.Products.Select(x=>new GoogleChart
                {
                    Productname=x.ProductName,
                    Productstock=x.ProductStock
                }).ToList();
            }
            return newClass1;
        }
        public ActionResult LineChart()
        {
            return View();
        }
        public ActionResult ColumnChart()
        {
            return View();
        }
    }
}