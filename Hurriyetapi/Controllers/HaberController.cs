using Hurriyetapi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hurriyetapi.Controllers
{
    public class HaberController : Controller
    {
            public ActionResult Index()
            {
                var apikey = "?apikey=99b19701e3b74b4bb1f18468e5931e51";
                var requesturl = "https://api.hurriyet.com.tr/v1/articles";
                var fullurl = string.Concat(requesturl, apikey);
                StringBuilder builder = new StringBuilder();
                WebRequest request = WebRequest.Create(fullurl);
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var veri = reader.ReadToEnd();
                List<Haber> veriler = JsonConvert.DeserializeObject<List<Haber>>(veri);
                HaberModel model = new HaberModel();
                model.Haber = veriler;
                return View(model);
            }
            public ActionResult HaberEdit(int id = 0)
            {

                var apikey = "?apikey=99b19701e3b74b4bb1f18468e5931e51";
                var requesturl = "https://api.hurriyet.com.tr/v1/articles";
                var fullurl = string.Concat(requesturl, apikey) + "&Id=" + id;
                StringBuilder builder = new StringBuilder();
                WebRequest request = WebRequest.Create(fullurl);
                request.ContentType = "text/html";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true);
                var veri = reader.ReadToEnd();


                JObject rss = JObject.Parse(veri);
                var Files = (JArray)rss["Files"];
                var Fileses = Files.ToObject<List<Filess>>();

                Haberinfo model = new Haberinfo
                {
                    Id = (int)rss["Id"],
                    ContentType = (string)rss["ContentType"],
                    CreatedDate = (string)rss["CreatedDate"],
                    Description = (string)rss["Description"],
                    Editor = (string)rss["Editor"],
                    Text = (string)rss["Text"],
                    Files = Fileses
                };
                string htmlBaslik2 = HttpUtility.HtmlDecode(model.Text);
                //string noHTML = Regex.Replace(htmlBaslik2, @"<[^>]+>|&nbsp;", "").Trim();
                model.Text = htmlBaslik2;
                return View(model);
            }



     }
}
