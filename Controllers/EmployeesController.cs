using businessStaff2.Data;
using businessStaff2.Models;
using businessStaff2.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace businessStaff2.Controllers
{
    [Authorize]
    public class EmployeesController : Controller 
    {
        public readonly BaseContext _context; 
        public EmployeesController(BaseContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Employees.ToListAsync());
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
        
        [Authorize(Roles = "Admin")]
        public IActionResult Create() 
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost] 
        public IActionResult Create(Employee e)
        {
            try
            {
                if(ModelState.IsValid){
                    e.Status = "Active";
                    _context.Employees.Add(e);
                    _context.SaveChanges(); 
                    //crear usuarios(e)
                    Console.WriteLine(TheHelpercito.GenerateUserName(e.FirstName,e.LastName,e.Document));
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error","Home");
            }
            catch 
            {
                return RedirectToAction("Error","Home");
            }
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if(id != null)
                {
                    var employee = await _context.Employees.FindAsync(id);
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error","Home");
            }
            catch
            {
                return RedirectToAction("Error","Home");
            }
        }
    }
}
