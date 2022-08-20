using Microsoft.AspNetCore.Mvc;

namespace EmmanuilWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
