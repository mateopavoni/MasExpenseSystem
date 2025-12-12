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
    }
}
