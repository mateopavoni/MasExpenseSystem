using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using MasExpenseSystem.Managers;
using MasExpenseSystem.Models;
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

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(ServiceVM vm)
        {

            if (!ModelState.IsValid) return View(vm);

            vm.UserId = 1;
            var response = _manager.New(vm);
            if (response == 1) return RedirectToAction("index");

            ViewBag.message = "ERROR: Error en registrar el service.";
            return View();
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var model = _manager.GetById(id);
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(ServiceVM model)
        {
            if(!ModelState.IsValid) return View(model);
            var response = _manager.Edit(model);
            if(response == 1) return RedirectToAction("index");

            ViewBag.message = "ERROR: Error al editar el service.";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var response = _manager.Delete(id);
            return RedirectToAction("index");
        }
    }
}
