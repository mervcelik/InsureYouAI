using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class BlogController : Controller
{
    private readonly InsureContext _context;

    public BlogController(InsureContext context)
    {
        _context = context;
    }

    public IActionResult BlogList()
    {
        return View();
    }
    public IActionResult BlogDetail(int id)
    {
        ViewBag.i = id;
        TempData["id"] = id;
        return View();
    }

    public PartialViewResult GetBlog()
    {
        return PartialView();
    }
    [HttpPost]
    public IActionResult SubscriGetBlogbeEmail(string keyword)
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult AddComment()
    {
        ViewBag.id = TempData["id"];
        return PartialView();
    }
    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        comment.CommentDate = DateTime.Now;
        comment.AppUserId = "59b730a8-7986-4cf7-8964-c5a66de42f23";
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return RedirectToAction("BlogList");
    }
}
