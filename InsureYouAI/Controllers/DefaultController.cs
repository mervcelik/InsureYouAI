using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public PartialViewResult SendMessage()
    {
        return PartialView();
    }
    public IActionResult SendMessage(string message)
    {
        return View();
    }

    public PartialViewResult SubscribeEmail()
    {
        return PartialView();
    }
    public IActionResult SubscribeEmail(string email)
    {
        return View();
    }

}
