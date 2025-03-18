using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class AdminController : Controller
{
    private const string AdminUsername = "admin";
    private const string AdminPassword = "password123";

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == AdminUsername && password == AdminPassword)
        {
            HttpContext.Session.SetString("AdminUser", username);
            return RedirectToAction("Dashboard");
        }
        else
        {
            ViewBag.Error = "Invalid username or password";
            return View();
        }
    }

    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("AdminUser") == null)
        {
            return RedirectToAction("Login");
        }

        return View("admin_dashboard");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminUser");
        return RedirectToAction("Login");
    }
}
