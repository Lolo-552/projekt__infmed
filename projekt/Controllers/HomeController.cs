using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projekt.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize] // Atrybut autoryzacji wymaga zalogowania użytkownika
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous] // Atrybut `AllowAnonymous` pozwala na dostęp do tej akcji bez wymagania autoryzacji
        public IActionResult Login()
        {
            // Kod logiki logowania, jeśli wymagany

            // Po pomyślnym zalogowaniu przekieruj użytkownika do strony Home/Index
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
