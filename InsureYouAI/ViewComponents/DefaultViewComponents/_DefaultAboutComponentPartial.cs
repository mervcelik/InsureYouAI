using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultAboutComponentPartial : ViewComponent
{
    private readonly InsureContext _context;

    public _DefaultAboutComponentPartial(InsureContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.title= _context.Abouts.Select(a => a.Title).FirstOrDefault();
        ViewBag.description= _context.Abouts.Select(a => a.Description).FirstOrDefault();
        ViewBag.imageUrl= _context.Abouts.Select(a => a.ImageUrl).FirstOrDefault();
        var values = _context.AboutItems.ToList();
        return View(values);
    }
}