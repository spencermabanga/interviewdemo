using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InterviewDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InterviewDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new SearchModel());
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                var ourData = GetData(model.SearchName);

                if (!ourData.Any()) return View();
                //Search for the matching name/id
                List<GitUsers> matchingList = new GitUsersList();
                matchingList.AddRange(ourData.Where(match => match.id.Contains(model.SearchName)));

                if (matchingList.Any())
                {
                    return matchingList.Count == 1 ? View("ResultsSingle", ourData[0]) : View("Results", matchingList);
                }

                return View("Results", ourData);
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<GitUsers> GetData(string name)
        {
            var model = string.Empty;
            var client = new HttpClient();
            var task = client.GetAsync("http://api.usa.gov/jobs/search.json?query=nursing+jobs")
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  model = jsonString.Result;

              });
            task.Wait();

            var returnData = JsonConvert.DeserializeObject<GitUsersList>(model);

           
            return returnData;
        }
    }

}