using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SynthBoardCollab.Models;

namespace SynthBoardCollab.Controllers;

public class HomeController : Controller
{

    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID != null)
        {
            return RedirectToAction("Dashboard", "User");
        }
        return RedirectToAction("LogReg", "User");
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
