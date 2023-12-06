using EFTest.Database;
using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (var test = new EFDB())
            {
                var myAnimeInsert = new AniList()
                {
                    Name = "BLEACH",
                    Description = "Save Soul Society",
                    ReleasedDate = DateTime.Now,
                };
                test.AnimeProp.Add(myAnimeInsert);
                test.SaveChanges();
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}