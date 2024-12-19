using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceMVC.Controllers
{
    public class LienHeController : Controller
    {


        private readonly ILogger<LienHeController> _logger;

        public LienHeController(ILogger<LienHeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/404")]
        public IActionResult PageNotFound()
        {
            return View();
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
