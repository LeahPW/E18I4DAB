using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProsumerGrid.Models;
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Services.Prosumer;

namespace ProsumerGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // GET: ApiTest
        public ActionResult ApiTest()
        {
            IEnumerable<ProsumerInfoDTO> prosumers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:14065/api/");

                var responseTask = client.GetAsync("prosumers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProsumerInfoDTO>>();
                    readTask.Wait();

                    prosumers = readTask.Result;
                }
                else 
                {
                    prosumers = Enumerable.Empty<ProsumerInfoDTO>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(prosumers);
        }

        //private ProsumerService _prosumerService;

        //public ProsumerController()
        //{
        //    _prosumerService = new ProsumerService();
        //}

        //// GET: Prosumers
        //public async Task<ActionResult> Index()
        //{
        //    //var prosumers = db.Prosumers.Include(p => p.SmartMeter);
        //    //IEnumerable<ProsumerDTO> prosumers = null;

        //    //using (var client = new HttpClient())
        //    //{
        //    //    client.BaseAddress = new Uri("http://localhost:14065/api/");

        //    //    var responseTask = client.GetAsync("prosumers");
        //    //    responseTask.Wait();

        //    //    var result = responseTask.Result;
        //    //    if (result.IsSuccessStatusCode)
        //    //    {
        //    //        var readTask = result.Content.ReadAsAsync<IList<ProsumerDTO>>();
        //    //        readTask.Wait();

        //    //        prosumers = readTask.Result;
        //    //    }
        //    //    else
        //    //    {
        //    //        prosumers = Enumerable.Empty<ProsumerDTO>();
        //    //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //    //    }
        //    //}

        //    List<ProsumerInfoDTO> prosumers = _prosumerService.GetAllProsumers();
        //    return View(prosumers);
        //}
    }
}
