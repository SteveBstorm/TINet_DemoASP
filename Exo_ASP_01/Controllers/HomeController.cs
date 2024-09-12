using Exo_ASP_01.Models;
using Exo_ASP_01.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
            // Générer la page de formulaire lors d'une requete GET
            return View();
        }

        [HttpPost]
        public IActionResult Contact([FromForm]ContactFormModel model)
        {
            // Traiter les données du formulaire lors d'une requete POST

            if(ModelState.IsValid)
            { 
                ContactService.Contacts.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet("{email}")]
        public IActionResult Detail(string email)
        {
            ContactFormModel toDisplay = ContactService.Contacts.FirstOrDefault(x => x.Email == email);
            return View(toDisplay);
        }

        public IActionResult Delete(string email)
        {
            ContactFormModel toDelete = ContactService.Contacts.FirstOrDefault(x => x.Email == email);

            ContactService.Contacts.Remove(toDelete);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(string email)
        {
            ContactFormModel toUpdate = ContactService.Contacts.FirstOrDefault(x => x.Email == email);

            return View(toUpdate);
        }

        [HttpPost]
        public IActionResult Update(ContactFormModel model)
        {
            if(!ModelState.IsValid) return View(model);

            ContactFormModel toUpdate = ContactService.Contacts.FirstOrDefault(x => x.Email == model.Email);
            
            ContactService.Contacts.Remove(toUpdate);
            ContactService.Contacts.Add(model);
            return RedirectToAction(nameof(Index));
        }

    }
}
