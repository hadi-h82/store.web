using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.Controllers;

public class HomeController : UserPanelBaseController
{
    [HttpGet("Home")]
    public IActionResult Index()
    {
        return View();
    }
}
