using Exo_ASP_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo_ASP_01.Controllers
{
    public class DestinationController : Controller
    {
        private List<DestinationViewModel> _Destinations = new List<DestinationViewModel>
        {
            new DestinationViewModel
            {
                Id = 1,
                Name = "Visite de tokyo",
                Country = "Japon",
                Description = "C'est une ile avec des gens 👹"
            },
            new DestinationViewModel
            {
                Id = 2,
                Name = "La tour Eiffel",
                Country = "France",
                Description = null
            }
        };

        public IActionResult Index()
        {
            return View(_Destinations);
        }

        public IActionResult Detail([FromRoute]int id)
        {
            DestinationViewModel? destination = _Destinations.SingleOrDefault(d => d.Id == id);

            if (destination is null)
            {
                return RedirectToAction(nameof(Perdu));
            }
            return View(destination);
        }

        public IActionResult Perdu()
        {
            Response.StatusCode = 404;
            return View();
        }

        public IActionResult DestDuJour()
        {
            Random rng = new Random(DateTime.Today.GetHashCode());
            int index = rng.Next(0, _Destinations.Count);

            int idTarget = _Destinations[index].Id;

            return RedirectToAction(nameof(Detail), new { id = idTarget });
        }
    }
}
