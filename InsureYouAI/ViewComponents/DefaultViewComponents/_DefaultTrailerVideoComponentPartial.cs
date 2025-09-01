﻿using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponenets.DefaultViewComponents;

public class _DefaultTrailerVideoComponentPartial:ViewComponent
{
    private readonly InsureContext _context;

    public _DefaultTrailerVideoComponentPartial(InsureContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values= _context.TrailerVideos.ToList();
        return View(values);
    }
}
