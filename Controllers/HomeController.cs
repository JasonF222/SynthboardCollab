using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Synthboard.Models;

namespace Synthboard.Controllers;

public class HomeController : Controller
{

    [HttpGet]
    [Route("/")]
    public IActionResult SynthboardSkeleton()
    {
        return View("SynthboardSkeleton");
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
