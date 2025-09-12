using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace InsureYouAI.Controllers;

public class ArticleController : Controller
{
    private readonly InsureContext _context;
    private readonly IConfiguration _configuration;
    public ArticleController(InsureContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
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


    [HttpGet]
    public IActionResult CreateArticleWithOpenAI()
    {
        return View();
    }

    public async Task<IActionResult> CreateArticleWithOpenAI(string prompt)
    {
        var apiKey = _configuration["OpenAI:ApiKey"]; ;
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var requestData = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                    new {role="system",content="Sen bir sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın. Kullanıcının verdiği özet ve anahtar kelimelere göre, sigortacılık sektörüyle ilgili makale üret. En az 5000 karakter olsun."},
                    new{role="user",content=prompt }
                },
            temperature = 0.7
        };

        var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            var content = result.choices[0].message.content;
            ViewBag.article = content;
        }
        else
        {
            ViewBag.article = "Bir hata oluştu: " + response.StatusCode;
        }
        return View();
    }

    public class OpenAIResponse
    {
        public List<Choice> choices { get; set; }
    }
    public class Choice
    {
        public Message message { get; set; }
    }
    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
