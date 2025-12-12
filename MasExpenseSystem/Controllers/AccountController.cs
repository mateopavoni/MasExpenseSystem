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
    }
}
