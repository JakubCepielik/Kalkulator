using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.Godzina = DateTime.Now.Hour;
            ViewBag.Powitanie = ViewBag.godzina < 17 ? "Dzień dobry" : "Dobry wieczór";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Kowalska"},
                new Dane {Name = "Monika", Surname = "Kot"},
                new Dane {Name = "Jan", Surname = "Lis"},
            };


            return View(osoby);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}