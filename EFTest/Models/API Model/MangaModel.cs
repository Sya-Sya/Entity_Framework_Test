using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFTest.Models.API_Model
{
    #region Main model
    public class MainMangaModel
    {
        public List<MangaModel> Top10MangaList { get; set; } = new List<MangaModel>();
        public RandomMangaModel RandomManga { get; set; } = new RandomMangaModel();
        public List<SearchedManga> SearchedMangaList { get; set; } = new List<SearchedManga>();
    }
    #endregion

    #region Manga Model
    public class MangaModel
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string cover { get; set; }
        public string synopsis { get; set; }
        public chapters chapters { get; set; }
        public List<string> genres { get; set; }
    }
    public class chapters
    {
        public string total { get; set; }
        public string lang { get; set; }
    }
    #endregion

    #region Random Manga Model
    public class RandomMangaModel
    {
        public int manga_id { get; set; }
        public string title { get; set; }
        public string alt_title { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string published { get; set; }
        public double score { get; set; }
        public int views { get; set; }
        public string cover { get; set; }
        public string synopsis { get; set; }
        public List<string> genres { get; set; }
        public List<string> authers { get; set; }
        public List<string> mangazines { get; set; }
        public List<Chapter> chapters { get; set; }
        public List<Volume> volumes { get; set; }
    }
    public class Chapter
    {
        public string total { get; set; }
        public string lang { get; set; }
    }
    public class Volume
    {
        public string total { get; set; }
        public string lang { get; set; }
    }
    #endregion

    #region Searched Manga Model
    public class SearchedManga
    {
        public int id { get; set; }
        public int manga_id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string cover { get; set; }
        public List<string> langs { get; set; }
        public Chapters chapters { get; set; }
    }
    public class Chapters
    {
        public string total { get; set; }
        public string lang { get; set; }
    }
    #endregion
}