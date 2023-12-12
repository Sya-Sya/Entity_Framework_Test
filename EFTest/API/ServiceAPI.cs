using EFTest.Models.API_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EFTest.API
{
    public class ServiceAPI
    {
        private string BaseURL = "https://manga-apiv1.vercel.app";
        public CommonAPIResponseModel top10manga(string offset = "", string limit = "")
        {
            CommonAPIResponseModel model = new CommonAPIResponseModel();
            try
            {
                string remURL = BaseURL + "/api/top-10?offset=0&limit=10";
                HttpWebRequest request = WebRequest.Create(remURL) as HttpWebRequest;
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string rstl = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(rstl))
                {
                    model.code = "666";
                    model.status = "Failed";
                    model.message = "Failed to get response";
                    model.data = null;
                    return model;
                }
                else
                {
                    List<MangaModel> mangaList = JsonConvert.DeserializeObject<List<MangaModel>>(rstl);
                    model.code = "000";
                    model.status = "Success";
                    model.message = "oK";
                    model.data = mangaList;
                }
            }
            catch (Exception ex)
            {
                model.code = "999";
                model.status = "Failed";
                model.message = "UWU";
                model.data = ex;
            }
            return model;
        }
        public CommonAPIResponseModel getrandomMange()
        {
            CommonAPIResponseModel model = new CommonAPIResponseModel();
            try
            {
                string remURL = BaseURL + "/api/random";
                HttpWebRequest request = WebRequest.Create(remURL) as HttpWebRequest;
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string rstl = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(rstl))
                {
                    model.code = "666";
                    model.status = "Failed";
                    model.message = "Failed to get response";
                    model.data = null;
                    return model;
                }
                else
                {
                    RandomMangaModel RandomManga = JsonConvert.DeserializeObject<RandomMangaModel>(rstl);
                    model.code = "000";
                    model.status = "Success";
                    model.message = "oK";
                    model.data = RandomManga;
                }
            }
            catch (Exception ex)
            {
                model.code = "999";
                model.status = "Failed";
                model.message = "UWU";
                model.data = ex;
            }
            return model;
        }
        public CommonAPIResponseModel getSpeceficMange(string MangaSlug)
        {
            CommonAPIResponseModel model = new CommonAPIResponseModel();
            try
            {
                if (string.IsNullOrEmpty(MangaSlug))
                {
                    model.code = "696";
                    model.status = "Parameter Missing";
                    model.message = "Slug Is Missing";
                    model.data = null;
                    return model;
                }
                string remURL = BaseURL + "/api/manga";
                remURL = remURL + "/" + MangaSlug;
                HttpWebRequest request = WebRequest.Create(remURL) as HttpWebRequest;
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string rstl = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(rstl))
                {
                    model.code = "666";
                    model.status = "Failed";
                    model.message = "Failed to get response";
                    model.data = null;
                    return model;
                }
                else
                {
                    RandomMangaModel RandomManga = JsonConvert.DeserializeObject<RandomMangaModel>(rstl);
                    model.code = "000";
                    model.status = "Success";
                    model.message = "oK";
                    model.data = RandomManga;
                }
            }
            catch (Exception ex)
            {
                model.code = "999";
                model.status = "Failed";
                model.message = "UWU";
                model.data = ex;
            }
            return model;
        }
        public CommonAPIResponseModel GetSearchedManga(string MangaName, string offset = "0", string limit = "10", string page = "1")
        {
            CommonAPIResponseModel model = new CommonAPIResponseModel();
            try
            {
                if (string.IsNullOrEmpty(MangaName))
                {
                    model.code = "696";
                    model.status = "Parameter Missing";
                    model.message = "Slug Is Missing";
                    model.data = null;
                    return model;
                }
                string remURL = BaseURL + "/api/search";
                remURL = remURL + "?keyword=" + MangaName + "&page=" + page + "&offset=" + offset + "&limit=" + limit;
                HttpWebRequest request = WebRequest.Create(remURL) as HttpWebRequest;
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string rstl = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(rstl))
                {
                    model.code = "666";
                    model.status = "Failed";
                    model.message = "Failed to get response";
                    model.data = null;
                    return model;
                }
                else
                {
                    List<SearchedManga> RandomManga = JsonConvert.DeserializeObject<List<SearchedManga>>(rstl);
                    model.code = "000";
                    model.status = "Success";
                    model.message = "oK";
                    model.data = RandomManga;
                }
            }
            catch (Exception ex)
            {
                model.code = "999";
                model.status = "Failed";
                model.message = "UWU";
                model.data = ex;
            }
            return model;
        }
    }
}