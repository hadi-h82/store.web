using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.Controllers
{
    public class ProfileController : UserPanelBaseController
    {
        [HttpGet("EditProfile")]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpGet("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();

        }
    }
}
