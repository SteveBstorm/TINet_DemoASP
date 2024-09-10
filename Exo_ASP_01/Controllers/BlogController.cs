using Microsoft.AspNetCore.Mvc;

namespace Exo_ASP_01.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
