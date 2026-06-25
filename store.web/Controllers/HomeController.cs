using Microsoft.AspNetCore.Mvc;

namespace store.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
