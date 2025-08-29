using InsureYouAI.Dtos;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers;
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }

    public IActionResult CreateUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRegisterDto createUserRegisterDto)
    {
        AppUser user = new AppUser
        {
            Name = createUserRegisterDto.Name,
            Surname = createUserRegisterDto.surname,
            Email = createUserRegisterDto.Email,
            UserName = createUserRegisterDto.UserName,
            ImageUrl = "Test",
            Description = "açıklama",
        };
        var result = await userManager.CreateAsync(user, createUserRegisterDto.Password);
        return RedirectToAction("UserList");
    }
}
