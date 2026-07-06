using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.Controllers;

[Authorize]
[Area("UserPanel")]
[Route("Panel")]
public class UserPanelBaseController : Controller
{

}
