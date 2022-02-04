using CicekSepeti.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CicekSepeti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        //public async Task<IActionResult> Index()
        //{
        //    using var httpClient = new HttpClient();
        //    var responseMessage = await httpClient.GetAsync("http://localhost:23946/api/Product");

        //    var Jsonstring = await responseMessage.Content.ReadAsStringAsync();

        //    var categories = JsonConvert.DeserializeObject<List<Product>>(Jsonstring);


        //    return
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
