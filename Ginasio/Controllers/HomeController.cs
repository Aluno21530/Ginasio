using Ginasio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ginasio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery(Name = "nome")] string nome)
        {
            Praticantes pt = new Praticantes();
            pt.Nome = nome;
            return View(pt);
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