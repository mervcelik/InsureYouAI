using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultNavbarComponentPartial:ViewComponent
{

    public IViewComponentResult Invoke()
    {
        return View();
    }
}
