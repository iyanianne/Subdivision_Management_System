using Microsoft.AspNetCore.Mvc;

namespace Subdivision_Management_System.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "staff@example.com" && password == "password123")
            {
                return RedirectToAction("Dashboard");
            }

            ViewData["Error"] = "Invalid email or password.";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
