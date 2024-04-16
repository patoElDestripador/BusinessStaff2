using businessStaff2.Data;
using businessStaff2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
  public class UsersController : Controller
  {
    public readonly BaseContext _context;

    public UsersController (BaseContext context) 
    {
      _context = context;
    }

    public async Task<IActionResult> Index ()
    {
      return View(await _context.CheckInCheckOuts.ToListAsync());
    }

    public IActionResult Login ()
    {
      return View();
    }

    [HttpGet]
    public async Task<IActionResult> Login (string userName, string password)
    {
      var userSearch = _context.Users.AsQueryable();
      if (!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password))
      {
        userSearch = userSearch.Where ( u => u.UserName.Equals(userName));
        Console.WriteLine("Hello world");
        Console.WriteLine(userSearch.ToString());
        // userSearch = userSearch.Equals();
        return RedirectToAction("Index", "CheckInCheckOuts", new {area = ""});
      }
      
      return View();
    }
  }

}