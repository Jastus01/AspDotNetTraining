using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewspaperCMS.DomainObjects;
using NewspaperCMS.Models;
using NewspaperCMS.Services;

namespace NewspaperCMS.Controllers;

public class HomeController : Controller
{
    private readonly INewspaperService _newspaperService;

    public HomeController(INewspaperService newspaperService)
    {
        _newspaperService = newspaperService;
    }
    public IActionResult Index()
    {
        Article article = new Article
        {
            Id = 1000,
            Title = "Starmer Resigns",
            Author = new Author{Name = "A.Reporter", Title = "Editor"}
            
        };
        
        return View(article);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}