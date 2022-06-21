using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
    [Route("board/play")]
    public IActionResult PlayBoard(int id)
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        Board? oneBoard = _context.Boards.FirstOrDefault(b => b.BoardID == id);
        return View(oneBoard);
    }

    
}