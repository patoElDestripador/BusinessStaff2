
using businessStaff2.Data;
using businessStaff2.Models;
using businessStaff2.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace businessStaff2.Controllers
{
    public class CheckInCheckOutsController : Controller
    {
        public readonly BaseContext _context;
        public CheckInCheckOutsController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string userId = HttpContext.Session.GetString("UserId");
            Console.WriteLine($"User id= {userId}");
            try
            {
                return TheHelpercito.Guardian(userId);
                // return View(await _context.TheViewSita.ToListAsync());
            }
            catch (Exception err)
            {   
                return View(await _context.TheViewSita.ToListAsync());
                // return RedirectToAction("Error","Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> CloseConection () 
        {
            int tableId = int.Parse(HttpContext.Session.GetString("TableId"));


            CheckInCheckOut checkOut = await _context.CheckInCheckOuts.FirstOrDefaultAsync(u => u.Id == tableId);

            checkOut.DepartureHour = DateTime.Now;
            _context.CheckInCheckOuts.Update(checkOut);
            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> CreateConection () 
        {   
            // Create table record
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            CheckInCheckOut checkIn = new CheckInCheckOut();
            checkIn.IdUser = userId; 
            checkIn.EntryHour = DateTime.Now;
            _context.Add(checkIn);
            _context.SaveChanges();
            var checkInEntry = await _context.CheckInCheckOuts
                .OrderBy(u => u.Id)
                .LastOrDefaultAsync(u => u.IdUser == userId);
            HttpContext.Session.SetString("TableId", checkInEntry.Id.ToString());
            return RedirectToAction("Index");
        }
    }
}