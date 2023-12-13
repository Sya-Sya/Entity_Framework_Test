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
        private ServiceAPI _api;
        public HomeController()
        {
            _api = new ServiceAPI();
        }
        public ActionResult Index(MainMangaModel model)
        {
            var getRandomManga = _api.getrandomMange();
            model.RandomManga = getRandomManga.data.MapObject<RandomMangaModel>();
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
            var getList = _api.top10manga("0","10");
            var getRandomManga = _api.getrandomMange();
            model.Top10MangaList = getList.data.MapObjects<MangaModel>();
            model.RandomManga = getRandomManga.data.MapObject<RandomMangaModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult GetManga(string MangaSlug)
        {
            MainMangaModel model = new MainMangaModel();
            var getClickedManga = _api.getSpeceficMange(MangaSlug);
            model.RandomManga = getClickedManga.data.MapObject<RandomMangaModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchManga(string MangaName)
        {
            MainMangaModel model = new MainMangaModel();
            var getClickedManga = _api.GetSearchedManga(MangaName);
            model.RandomManga = getClickedManga.data.MapObject<RandomMangaModel>();
            return View(model);
        }
    }
}