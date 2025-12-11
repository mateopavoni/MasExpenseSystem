using MasExpenseSystem.DTOs;
using MasExpenseSystem.Managers;
using Microsoft.AspNetCore.Mvc;

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
        var userId = 1;
        var services = _serviceManager.GetByType(userId, typeService);
        return Ok(services);
    }

    [HttpPost]
    public IActionResult New([FromBody] TransactionDTO modelDto)
    {
        modelDto.UserId = 1; 
        var result = _transactionManager.New(modelDto);
        return Ok(result);
    }

}
