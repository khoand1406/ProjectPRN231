using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPRN231.Models.Auth;

namespace ProjectPRN231.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would authenticate the user here
                // against a database or other authentication mechanism.
                if (model.Email == "test@example.com" && model.Password == "password")
                {
                    // Authentication successful, redirect to another page
                    return RedirectToAction("Index", "Home"); // Example redirection
                }
                else
                {
                    // Authentication failed
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If ModelState is not valid or authentication fails, return the view with errors
            return View(model);
        }
    }
}
