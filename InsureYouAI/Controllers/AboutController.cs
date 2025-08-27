﻿using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;
public class AboutController : Controller
{
    private readonly InsureContext _context;

    public AboutController(InsureContext context)
    {
        _context = context;
    }

    public IActionResult AboutList()
    {
        var values = _context.Abouts.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateAbout()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateAbout(About about)
    {
        _context.Abouts.Add(about);
        _context.SaveChanges();
        return RedirectToAction("AboutList");
    }
    [HttpGet]
    public IActionResult UpdateAbout(int Id)
    {
        var value = _context.Abouts.Find(Id);
        return View(value);
    }
    [HttpPost]
    public IActionResult UpdateAbout(About about)
    {
        _context.Abouts.Update(about);
        _context.SaveChanges();
        return RedirectToAction("AboutList");
    }


    public IActionResult DeleteAbout(int Id)
    {
        var value = _context.Abouts.Find(Id);
        _context.Abouts.Remove(value);
        _context.SaveChanges();
        return RedirectToAction("AboutList");
    }
}
