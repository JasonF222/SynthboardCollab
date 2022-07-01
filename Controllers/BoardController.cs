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

    [HttpPost]
    [Route("boards/submit/soundfile")]
    public IActionResult SaveSound(SoundFile newSound)
    {
        if(ModelState.IsValid)
        {
            int? UID = HttpContext.Session.GetInt32("UserID");
            if(UID == null)
                {
                    ViewBag.NotLogged = "You must Login or Register to view content.";
                    return RedirectToAction("LogReg", "User");
                }
            int userID = Convert.ToInt32(UID);
            List<SoundFile>? allRecord = _context.Sounds.Where(s => s.UserID == userID).ToList();
            if(allRecord.Count() > 9) 
            {
                ViewBag.Limit = "You have the maximum number of recordings. Please delete one to add new recordings.";
                return RedirectToAction("Dashboard", "User");
            }
            newSound.UserID = userID;
            _context.Sounds.Add(newSound);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","User");
        }
        if(newSound.BoardType == "triangle")
        {
            return View("Classic");
        }
        if(newSound.BoardType == "sawtooth")
        {
            return View("Fire");
        }
        if(newSound.BoardType == "sine")
        {
            return View("Water");
        }
        if(newSound.BoardType == "square")
        {
            return View("Space");
        }
        return RedirectToAction("Dashboard", "User");    
    }
}