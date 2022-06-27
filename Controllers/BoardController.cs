using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SynthBoardCollab.Models;

namespace SynthBoardCollab.Controllers;

public class BoardController : Controller
{
    private SynthContext _context;
    public BoardController(SynthContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/boards/space")]
    public IActionResult Space()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        return View();
    }

    [HttpGet]
    [Route("/boards/water")]

    public IActionResult Water()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        return View();
    }

    [HttpGet]
    [Route("/boards/fire")]
    public IActionResult Fire()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        return View();
    }

    [HttpGet]
    [Route("/boards/classic")]
    public IActionResult Classic()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        return View();
    }
    
}
testy westy
