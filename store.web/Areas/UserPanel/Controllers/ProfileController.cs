using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.Controllers
{
    public class ProfileController : UserPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
