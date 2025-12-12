using MasExpenseSystem.Managers;
using MasExpenseSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasExpenseSystem.Controllers
{
    public class AccountController(UserManager _userManager) : Controller
    {
        public IActionResult Login()
        {
            var viewModel = new LoginVM();
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var found = _userManager.Login(vm);
            if(found.UserId == 0)
            {
                ViewBag.Message = "No matching user found";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
