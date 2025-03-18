using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Subdivision_Management_System.Models;

namespace Subdivision_Management_System.Controllers;

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

    [HttpPost]
    public IActionResult Login(string email, string password)
    { 
        if (email == "alexa@gmail.com" && password == "password123")
        {
            return RedirectToAction("Dashboard");
        }

        ViewBag.ShowErrorMessage = true;
        ViewBag.ErrorMessage = "Invalid email or password. Please try again.";
        return View("Index");
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult Edit_Profile()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
