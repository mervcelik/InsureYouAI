﻿using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class ServiceController : Controller
{
    private readonly InsureContext _context;

    public ServiceController(InsureContext context)
    {
        _context = context;
    }

    public IActionResult ServiceList()
    {
        var values = _context.Services.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateService(Service service)
    {
        _context.Services.Add(service);
        _context.SaveChanges();
        return RedirectToAction("ServiceList");
    }
    [HttpGet]
    public IActionResult UpdateService(int Id)
    {
        var value = _context.Services.Find(Id);
        return View(value);
    }
    [HttpPost]
    public IActionResult UpdateService(Service service)
    {
        _context.Services.Update(service);
        _context.SaveChanges();
        return RedirectToAction("ServiceList");
    }


    public IActionResult DeleteService(int Id)
    {
        var value = _context.Services.Find(Id);
        _context.Services.Remove(value);
        _context.SaveChanges();
        return RedirectToAction("ServiceList");
    }
}
