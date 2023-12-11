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
        public MangaModel top10manga(string offset = "", string limit = "")
        {
            MangaModel model = new MangaModel();
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
                    model = JsonConvert.DeserializeObject<MangaModel>(rstl);
                    model.code = "000";
                    model.status = "Success";
                    model.message = "oK";
                    model.data = model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}