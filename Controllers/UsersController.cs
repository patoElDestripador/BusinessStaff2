using System.Security.Claims;
using businessStaff2.Data;
using businessStaff2.Helpers;
using businessStaff2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
  [Authorize]
  public class UsersController : Controller
  {
    public readonly BaseContext _context;

    public UsersController (BaseContext context) 
    {
      _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index ()
    {
      return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Login (string userName, string password)
    {
      var userSearch = _context.Users.AsQueryable();
      if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
      {
        try
        {
          // Remember that var get a type in first declaration
          var userInfo = userSearch.FirstOrDefault(u => u.UserName.Equals(userName));
          string descriptPassword = TheHelpercito.Decrypt(userInfo.Password);

          if (descriptPassword == password)
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
            return RedirectToAction("Index", "Home");
          }
        }
        catch (Exception)
        {
          return RedirectToAction("Error", "Home");
        }
      }
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Logout ()
    {
      // Clear server cookies
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }
  }
}