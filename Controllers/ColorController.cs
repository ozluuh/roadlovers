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
    public class ColorController : Controller
    {
        private readonly ILogger<ColorController> _logger;

        private IColorRepository _repo;

        public ColorController(ILogger<ColorController> logger, IColorRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.colors = _repo.FindAll();
            return View();
        }

        [HttpPost]
        public IActionResult Store(Color color)
        {
            _repo.Store(color);
            _repo.Commit();

            TempData["msg"] = "Cor registrada com sucesso";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}