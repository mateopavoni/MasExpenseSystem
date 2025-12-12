using MasExpenseSystem.Managers;
using MasExpenseSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MasExpenseSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController(UserManager _userManager) : Controller
    {
        public IActionResult Login()
        {
            var viewModel = new LoginVM();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var found = _userManager.Login(vm);

            if (found.UserId == 0)
            {
                ViewBag.Message = "Invalid email or password.";
                ViewBag.Class = "alert-danger";
                return View(vm);
            }

            // Claims del usuario
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, found.UserId.ToString()),
        new Claim(ClaimTypes.Name, found.FullName),
        new Claim(ClaimTypes.Email, found.Email)
    };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            var viewModel = new UserVM();
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            try
            {
                var response = _userManager.Register(vm);
                if (response != 0)
                {
                    ViewBag.Message = "Your account has been registered, please try loggin in";
                    ViewBag.Class = "alert-success";
                }
                else
                {
                    ViewBag.Message = "Registration failed";
                    ViewBag.Class = "alert-error";
                }
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Class = "alert-error";
            }

            return View();
        }
    }
}
