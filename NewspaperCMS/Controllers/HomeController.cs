using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewspaperCMS.DomainObjects;
using NewspaperCMS.Helpers;
using NewspaperCMS.Models;
using NewspaperCMS.Services;

namespace NewspaperCMS.Controllers;

public class HomeController : Controller
{
    private readonly INewspaperService _newspaperService;

    public HomeController(IConfiguration configuration, 
        IOptions<Settings> settings,
        INewspaperService newspaperService)
    {
        _newspaperService = newspaperService;

        int opinionPieces = configuration.GetValue<int>("Settings:FrontPage:NumberOfFrontPageOpinionPieces");

        int headlines = settings.Value.FrontPage!.NumberOfHeadlineArticles;
       
        int i = 0;
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