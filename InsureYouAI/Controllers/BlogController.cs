using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class BlogController : Controller
{
    public IActionResult BlogList()
    {
        return View();
    }

    public PartialViewResult GetBlog()
    {
        return PartialView();
    }
    public IActionResult SubscriGetBlogbeEmail(string keyword)
    {
        return View();
    }
}
