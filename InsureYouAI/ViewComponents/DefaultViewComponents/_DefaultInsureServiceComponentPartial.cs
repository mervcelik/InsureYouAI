using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultInsureServiceComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
