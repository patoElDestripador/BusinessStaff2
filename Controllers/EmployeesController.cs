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
        
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Create(Employee e)
        {
            try
            {
                e.Status = "Active";
                e.CreationTime = DateTime.Now;
                await _context.Employees.AddAsync(e);
                await _context.SaveChangesAsync(); 
                string userName = TheHelpercito.GenerateUserName(e.FirstName,e.LastName,e.Document);
                var lastEmployee = await _context.Employees.OrderByDescending(e => e.CreationTime).FirstOrDefaultAsync();

                User user = new User(){
                    IdEmployee = lastEmployee.Id,
                    Password = TheHelpercito.Encrypt(userName),
                    UserName = userName,
                    status = e.Status,
                    Rol = "Admin"
                };
                    _context.Users.Add(user);
                    _context.SaveChanges(); 
                return RedirectToAction("Index");
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
