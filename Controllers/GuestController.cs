using Microsoft.AspNetCore.Mvc;
using SynthBoardCollab.Models;

namespace SynthBoardCollab.Controllers;

public class GuestController : Controller
{
    private SynthContext _context;
    public GuestController(SynthContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/guest/dashboard")]
    public IActionResult GuestDash()
    {
        return View();
    }

    [HttpGet]
    [Route("/guest/fire")]
    public IActionResult GuestFire()
    {
        return View();
    }
    
    [HttpGet]
    [Route("/guest/classic")]
    public IActionResult GuestClassic()
    {
        return View();
    }

    [HttpGet]
    [Route("/guest/space")]
    public IActionResult GuestSpace()
    {
        return View();
    }

    [HttpGet]
    [Route("/guest/water")]
    public IActionResult GuestWater()
    {
        return View();
    }
}