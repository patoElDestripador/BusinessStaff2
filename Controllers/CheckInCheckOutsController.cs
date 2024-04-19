
using businessStaff2.Data;
using businessStaff2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            // Clear server cookies
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> CreateConection () 
        {   
            //generar independencia en cuanto la posibilidad de crear o eliminar la funcion
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

/*
1 - Validar usuarios en base a la password encriptada 
2 - Hacer que cuando se logge se redirija a el index Home 
3 - Independizar la funcionalidad que permite guarda la hora de entrada y hora de salida
4 - Agregarle funcionalidad a los botones check in & check out del index CheckICheckOuts 
5 - Eliminar La funcion de que cuando se loguear y desloguear se actualice la infromacion de entrad y salida
6 - Que cuando el usuario no este logueado no aparezca la img de cerrar session 
*/