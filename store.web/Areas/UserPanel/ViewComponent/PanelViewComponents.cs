using Microsoft.AspNetCore.Mvc;

namespace store.web.Areas.UserPanel.ViewComponents;

public class MenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("Menu");
    }
}
    