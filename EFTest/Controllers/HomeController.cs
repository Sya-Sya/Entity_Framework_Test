using EFTest.API;
using EFTest.Database;
using EFTest.Helpers;
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
        public ActionResult Index(MainMangaModel model)
        {
            ServiceAPI _api = new ServiceAPI();
            var getList = _api.top10manga("0", "10");
            model.Top10MangaList = getList.data.MapObjects<MangaModel>();
            return View(model);
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
        public ActionResult Top10Manga(MainMangaModel model)
        {
            ServiceAPI _api = new ServiceAPI();
            var getList = _api.top10manga("0","10");
            var getRandomManga = _api.getrandomMange();
            model.Top10MangaList = getList.data.MapObjects<MangaModel>();
            model.RandomManga = getRandomManga.data.MapObject<RandomMangaModel>();
            return View(model);
        }
    }
}