using Microsoft.AspNetCore.Mvc;
using UCrud.Models.Entities;
using UCrud.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace UCrud.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if user already exists
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser == null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "User already exists.");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserRole", user.Role);

                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (user.Role == "Student")
                {
                    return RedirectToAction("Dashboard", "Student");
                }
            }

            ViewBag.Error = "Invalid credentials!";
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session on logout
            return RedirectToAction("Login", "Account");
        }

    }
}
