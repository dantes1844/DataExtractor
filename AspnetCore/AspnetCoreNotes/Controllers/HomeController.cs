using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspnetCoreNotes.Models;
using Microsoft.Extensions.Hosting;

namespace AspnetCoreNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
           

            return View();
        }

        public IActionResult GetData(int i)
        {
            var file = $"{_hostEnvironment.ContentRootPath}/wwwroot/arateresult.csv";

            using var filestream = new FileStream(file, FileMode.Open);
            using var stremReader = new StreamReader(filestream, Encoding.Default);
            var text = stremReader.ReadToEnd();

            return null;
        }

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
