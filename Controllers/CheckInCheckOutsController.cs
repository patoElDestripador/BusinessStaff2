using businessStaff2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
  public class CheckInCheckOutsController : Controller
  {
    public readonly BaseContext _context;

    public CheckInCheckOutsController (BaseContext context) 
    {
      _context = context;
    }

    public async Task<IActionResult> Index ()
    {
      return View(await _context.CheckInCheckOuts.ToListAsync());
    }
  }
}