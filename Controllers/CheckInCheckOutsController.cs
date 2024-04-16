
using businessStaff2.Data;
using businessStaff2.Models;
using businessStaff2.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
    public class CheckInCheckOutsController : Controller
    {
        public readonly BaseContext _context; 
        public CheckInCheckOutsController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int Id)
        {
            string userId = HttpContext.Session.GetString("UserId");
            try
            {
                var registerSearch = _context.CheckInCheckOuts.Where(r => r.IdUser.Equals(int.Parse(userId)));
                return View(await registerSearch.ToListAsync());
                // return View(await _context.TheViewSita.ToListAsync());
            }
            catch (Exception err)
            {   
                return RedirectToAction("Error","Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }


    }
}