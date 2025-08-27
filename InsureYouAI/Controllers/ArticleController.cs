using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class ArticleController : Controller
{
    private readonly InsureContext _context;

    public ArticleController(InsureContext context)
    {
        _context = context;
    }

    public IActionResult ArticleList()
    {
        var values = _context.Articles.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateArticle()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateArticle(Article Article)
    {
        Article.CreatedDate = DateTime.Now;
        _context.Articles.Add(Article);
        _context.SaveChanges();
        return RedirectToAction("ArticleList");
    }
    [HttpGet]
    public IActionResult UpdateArticle(int Id)
    {
        var value = _context.Articles.Find(Id);
        return View(value);
    }
    [HttpPost]
    public IActionResult UpdateArticle(Article Article)
    {
        _context.Articles.Update(Article);
        _context.SaveChanges();
        return RedirectToAction("ArticleList");
    }


    public IActionResult DeleteArticle(int Id)
    {
        var value = _context.Articles.Find(Id);
        _context.Articles.Remove(value);
        _context.SaveChanges();
        return RedirectToAction("ArticleList");
    }
}
