using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultSliderComponentPartial : ViewComponent
{
    public readonly InsureContext _context;

    public _DefaultSliderComponentPartial(InsureContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Sliders.ToList();
        return View(values);
    }
}