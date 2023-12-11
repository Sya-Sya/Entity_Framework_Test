using EFTest.API;
using EFTest.Database;
using EFTest.Models;
using EFTest.Models.API_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceAPI _api;
        public HomeController(ServiceAPI sapi)
        {
            _api = sapi;
        }
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
        [HttpGet]
        public ActionResult Top10Manga(MangaModel model)
        {
            var getList = _api.top10manga("0","10");
            return View(getList);
        }
    }
}