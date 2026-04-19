using Microsoft.AspNetCore.Mvc;

namespace NewspaperCMS.Controllers;

public class ContactUsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}