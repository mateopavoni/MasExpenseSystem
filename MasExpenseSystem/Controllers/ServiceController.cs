using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using MasExpenseSystem.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasExpenseSystem.Controllers
{
    public class ServiceController(ServiceManager _manager) : Controller
    {
        
        public IActionResult Index()
        {
            var services = _manager.GetAll(1);
            return View(services);
        }
    }
}
