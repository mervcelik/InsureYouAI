﻿using Microsoft.AspNetCore.Identity;

namespace InsureYouAI.Entities;

public class AppUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Article> Articles { get; set; }
}
