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
    public class ManufacturerController : Controller
    {
        private readonly ILogger<ManufacturerController> _logger;

        private IManufacturerRepository _repo;

        public ManufacturerController(ILogger<ManufacturerController> logger, IManufacturerRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.manufacturers = _repo.FindAll();
            return View();
        }

        [HttpPost]
        public IActionResult Store(Manufacturer manufacturer)
        {
            _repo.Store(manufacturer);
            _repo.Commit();

            TempData["msg"] = "Fabricante cadastrada";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}