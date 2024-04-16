
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

        public async Task<IActionResult> Index()
        {
            try
            {

                var history = await _context.CheckInCheckOuts.ToListAsync();
                //var user = 
                return View();
            }
            catch
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