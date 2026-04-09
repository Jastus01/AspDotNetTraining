using Microsoft.AspNetCore.Mvc;
using Services;

namespace BuildSomethingMVC.Controllers;

[Route("[controller]")]
public class VideoController : Controller
{
    private readonly IVideoService _videoService;

    public VideoController(IVideoService videoService)
    {
        _videoService = videoService;
    }
    // GET
    public IActionResult Index()
    {
        return View(_videoService.GetAll());
    }
}