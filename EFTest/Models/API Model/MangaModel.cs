using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFTest.Models.API_Model
{
    public class MangaModel : CommonAPIResponseModel
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
}