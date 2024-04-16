using businessStaff2.Data;
using businessStaff2.Models;
using businessStaff2.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace businessStaff2.Controllers
{
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
        
        public IActionResult Create() 
        {
            return View();
        }

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
