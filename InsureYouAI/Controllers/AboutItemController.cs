﻿using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;
public class AboutItemController : Controller
{
    private readonly InsureContext _context;

    public AboutItemController(InsureContext context)
    {
        _context = context;
    }

    public IActionResult AboutItemList()
    {
        var values = _context.AboutItems.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateAboutItem()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateAboutItem(AboutItem aboutItem)
    {
        _context.AboutItems.Add(aboutItem);
        _context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }
    [HttpGet]
    public IActionResult UpdateAboutItem(int Id)
    {
        var value = _context.AboutItems.Find(Id);
        return View(value);
    }
    [HttpPost]
    public IActionResult UpdateAboutItem(AboutItem aboutItem)
    {
        _context.AboutItems.Update(aboutItem);
        _context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }


    public IActionResult DeleteAboutItem(int Id)
    {
        var value = _context.AboutItems.Find(Id);
        _context.AboutItems.Remove(value);
        _context.SaveChanges();
        return RedirectToAction("AboutItemList");
    }
}
