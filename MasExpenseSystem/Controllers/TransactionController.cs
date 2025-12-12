using MasExpenseSystem.DTOs;
using MasExpenseSystem.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace MasExpenseSystem.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ServiceManager _serviceManager;
        private readonly TransactionManager _transactionManager;

        public TransactionController(
            ServiceManager serviceManager,
            TransactionManager transactionManager)
        {
            _serviceManager = serviceManager;
            _transactionManager = transactionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ServicesByType(string typeService)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var services = _serviceManager.GetByType(int.Parse(userId), typeService);
            return Ok(services);
        }

        [HttpPost]
        public IActionResult New([FromBody] TransactionDTO modelDto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            modelDto.UserId = int.Parse(userId);
            var result = _transactionManager.New(modelDto);
            return Ok(result);
        }

        [HttpGet]

        public IActionResult History()
        {
            return View();
        }

        [HttpGet]

        public IActionResult HistoryTransaction(DateOnly startDate, DateOnly endDate)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;;
            var history = _transactionManager.GetHistory(startDate, endDate, int.Parse(userId));
            return Ok(new { data = history });
        }

    }
}
