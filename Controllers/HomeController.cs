using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using businessStaff2.Models;
using Microsoft.AspNetCore.Authorization;
namespace businessStaff2.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Unauthorized()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
