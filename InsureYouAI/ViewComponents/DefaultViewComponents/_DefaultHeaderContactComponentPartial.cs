using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultHeaderContactComponentPartial:ViewComponent
{
    public readonly InsureContext _context;

    public _DefaultHeaderContactComponentPartial(InsureContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.email=_context.Contacts.Select(c=>c.Email).FirstOrDefault();
        ViewBag.phone=_context.Contacts.Select(c=>c.Phone).FirstOrDefault();
        return View();
    }
}
