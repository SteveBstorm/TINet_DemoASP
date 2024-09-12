using Exo_ASP_01.Models;
using Exo_ASP_01.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exo_ASP_01.Controllers
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
            return View(ContactService.Contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            // G�n�rer la page de formulaire lors d'une requete GET
            return View();
        }

        [HttpPost]
        public IActionResult Contact([FromForm]ContactFormModel model)
        {
            // Traiter les donn�es du formulaire lors d'une requete POST

            if(ModelState.IsValid)
            { 
                ContactService.Contacts.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}
