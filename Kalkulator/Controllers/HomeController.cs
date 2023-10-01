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

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Kalkulator(Kalk kalk)
        {
            float x = 0;
			switch (kalk.Dzialanie)
            {
                case "1":
                    x = kalk.Liczba1 + kalk.Liczba2;
                    break;
				case "2":
                    x = kalk.Liczba1 - kalk.Liczba2;
					break;
				case "3":
                    x = kalk.Liczba1 * kalk.Liczba2;
					break;
				case "4":
                    x = kalk.Liczba1 / kalk.Liczba2;
					break;
                default:
                    break;
			}
            ViewBag.wynik = $"Wynik: {x}";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}