

using businessStaff2.Data;
using businessStaff2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
    public class EmployeesController
    {
    
        public readonly BaseContext _context; 
        public EmployeesController(BaseContext context)
        {
            _context = context;
        }
        
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());

        }
        

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if(id != null)
            {
                var employee = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }*/
    }
}