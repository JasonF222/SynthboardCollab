using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SynthBoardCollab.Models;

namespace SynthBoardCollab.Controllers;

public class UserController : Controller
{
    private SynthContext _context;
    public UserController(SynthContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("login/register")]
    public IActionResult LogReg()
    {
        int? UID = HttpContext.Session.GetInt32("UserId");
        if(UID != null)
        {
            return RedirectToAction("Dashbaord");
        }
        return View("LogReg");
    }

    [HttpGet]
    [Route("/user/dashboard")]
    public IActionResult Dashboard()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg");
        }
        int userID = Convert.ToInt32(UID);
        List<SoundFile> userRecordings = _context.Sounds.Where(s => s.UserID == userID).ToList();
        if(userRecordings.Count() > 9)
        {
            ViewBag.Limit = "You have the maximum number of recordings. Please delete one to add new recordings.";
        }
        User? oneUser = _context.Users.FirstOrDefault(u => u.UserID == UID);
        return View("Dashboard", oneUser);
    }
    
    [HttpPost]
    [Route("/user/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if( _context.Users.Any(u => u.Email == newUser.Email))
            { 
                ModelState.AddModelError("Email", " is already in use!");
                return LogReg();
            }
            PasswordHasher<User> PwHash = new PasswordHasher<User>();
            newUser.Password = PwHash.HashPassword(newUser, newUser.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserID", newUser.UserID);
            return RedirectToAction("Dashboard");
        }
        ViewBag.RegFailure = "There was a problem registering. Click Register to view errors.";
        return LogReg();
    }

    [HttpPost]
    [Route("/user/login")]
    public IActionResult Login(LogUser newLogUser)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == newLogUser.LogEmail);
            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail","Invalid Email or Password");
                ViewBag.LogFailure = "There was a problem logging in. Click Login to view errors.";
                return LogReg();
            }
            var PwHash = new PasswordHasher<LogUser>();
            var result = PwHash.VerifyHashedPassword(newLogUser, userInDb.Password,newLogUser.LogPass);
            if(result == 0 ){
                ModelState.AddModelError("LogEmail","Invalid Email or Password");
                ViewBag.LogFailure = "There was a problem logging in. Click Login to view errors.";
                return LogReg();
            }
            HttpContext.Session.SetInt32("UserID", userInDb.UserID);
            return RedirectToAction("Dashboard");
        }
        ViewBag.LogFailure = "There was a problem logging in. Click Login to view errors.";
        return LogReg();
    }

    [HttpGet]
    [Route("/user/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LogReg");
    }

    [HttpGet]
    [Route("/user/recordings/play/{id}")]
    public IActionResult PlayRecording(int id)
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg", "User");
        }
        SoundFile? oneRecord = _context.Sounds.FirstOrDefault(s => s.SoundFileID == id);
        return View("Playback", oneRecord);
    }

    [HttpGet]
    [Route("/user/recordings")]
    public IActionResult Recordings()
    {
        int? UID = HttpContext.Session.GetInt32("UserID");
        if(UID == null)
        {
            ViewBag.NotLogged = "You must Login or Register to view content.";
            return RedirectToAction("LogReg");
        }
        int userID = Convert.ToInt32(UID);
        List<SoundFile> userRecordings = _context.Sounds.Where(s => s.UserID == userID).ToList();
        if(userRecordings.Count() > 9)
        {
            ViewBag.Limit = "You have the maximum number of recordings. Please delete one to add new recordings.";
        }
        return View("Recordings", userRecordings);
    }

    [HttpGet]
    [Route("/user/recordings/delete/{id}")]
    public IActionResult DeleteRecording(int id)
    {
        SoundFile? oneRecord = _context.Sounds.FirstOrDefault(s => s.SoundFileID == id);
        if(oneRecord != null)
        {
            _context.Remove(oneRecord);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return RedirectToAction("Recordings");
    }
}