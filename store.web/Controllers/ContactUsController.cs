using Microsoft.AspNetCore.Mvc;

namespace store.web.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
