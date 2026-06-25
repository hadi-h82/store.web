using Microsoft.AspNetCore.Mvc;

namespace store.web.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet("AccesDenied")]
        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
