using Application.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.Controllers
{
    public class ProfileController : UserPanelBaseController
    {

        private readonly IUserService _userService;
        public ProfileController(IUserService userService)
        {
            _userService = userService;  
        }


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
