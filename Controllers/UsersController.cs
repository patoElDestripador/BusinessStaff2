using System.Security.Claims;
using businessStaff2.Data;
using businessStaff2.Helpers;
using businessStaff2.Models;
using Microsoft.AspNetCore.Authentication;
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

    public IActionResult Index ()
    {
      return View();
    }

    public async Task<IActionResult> Login (string userName, string password)
    {
      var userSearch = _context.Users.AsQueryable();
      if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
      {
        try
        {
          // Remember that var get a type in first declaration
          var userInfo = userSearch.FirstOrDefault(u => u.UserName.Equals(userName));
          if (userInfo.Password == password)
          {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.ID.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim(ClaimTypes.Role, userInfo.Rol)
            };

            var identity = new ClaimsIdentity(claims, "MyAuthenticationScheme");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            HttpContext.Session.SetString("UserId", userInfo.ID.ToString());
            // Pass values to check in
            return RedirectToAction("CreateConection", "CheckInCheckOuts");
          }
          // bool isValidPassword = userInfo.Password == password 
          //   ? true 
          //   : throw new NullReferenceException("Invalid password");
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