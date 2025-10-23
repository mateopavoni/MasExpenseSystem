using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MasExpenseSystem.Controllers
{
    public class ServiceController(AppDbContext _dbContext) : Controller
    {
        
        public IActionResult Index()
        {
            List<Service> services = _dbContext.Services.ToList();
            return View(services);
        }
    }
}
