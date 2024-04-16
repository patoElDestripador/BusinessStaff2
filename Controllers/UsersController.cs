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

    // public IActionResult Login ()
    // {
    //   return View();
    // }

    [HttpGet]
    public async Task<IActionResult> Login (string userName, string password)
    {
      var userSearch = _context.Users.AsQueryable();
      if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
      {
        try
        {
          // Remember that var get a type in first declaration
          var userInfo = userSearch.FirstOrDefault(u => u.UserName.Equals(userName));
          bool isValidPassword = userInfo.Password == password 
            ? true 
            : throw new NullReferenceException("Invalid password");

          HttpContext.Session.SetString("UserId", userInfo.ID.ToString());
          return RedirectToAction("Index", "CheckInCheckOuts");
        }
        catch (Exception)
        {
          return RedirectToAction("Error", "Home");
          throw;
        }
      }
      return RedirectToAction("Index");
    }
  }

}