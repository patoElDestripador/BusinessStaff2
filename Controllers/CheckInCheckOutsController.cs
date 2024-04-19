using businessStaff2.Data;
using businessStaff2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace businessStaff2.Controllers
{
    [Authorize]
    public class CheckInCheckOutsController : Controller
    {
        public readonly BaseContext _context;
        public CheckInCheckOutsController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TheViewSita.ToListAsync());
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
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateConection () 
        {   
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            // Create table record
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