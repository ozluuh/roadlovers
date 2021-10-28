using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using roadlovers.Models;
using roadlovers.Repositories;

namespace roadlovers.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly ILogger<VehicleTypeController> _logger;

        private IVehicleTypeRepository _repo;

        public VehicleTypeController(ILogger<VehicleTypeController> logger, IVehicleTypeRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.classes = _repo.FindAll();

            return View();
        }

        [HttpPost]
        public IActionResult Store(VehicleType type)
        {
            _repo.Store(type);
            _repo.Commit();

            TempData["msg"] = "Classe cadastrada com sucesso";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}