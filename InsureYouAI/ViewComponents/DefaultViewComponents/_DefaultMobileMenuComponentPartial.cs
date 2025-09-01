using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultMobileMenuComponentPartial : ViewComponent
{
    public readonly InsureContext _context;

    public _DefaultMobileMenuComponentPartial(InsureContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.email = _context.Contacts.Select(c => c.Email).FirstOrDefault();
        ViewBag.phone = _context.Contacts.Select(c => c.Phone).FirstOrDefault();
        return View();
    }
}
