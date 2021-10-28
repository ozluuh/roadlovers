using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using roadlovers.Models;
using roadlovers.Persistence;
using roadlovers.Repositories;

namespace roadlovers.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository _repo;

        private IManufacturerRepository _repoManufacturer;

        private IVehicleTypeRepository _repoVehicleClasses;

        private IColorRepository _repoColor;

        private IVehicleColorRepository _repoVehCol;

        public CarController(ICarRepository repo, IManufacturerRepository repoManufacturer, IVehicleTypeRepository repoVehicleClasses, IColorRepository repoColor, IVehicleColorRepository repoVehCol)
        {
            _repo = repo;
            _repoManufacturer = repoManufacturer;
            _repoVehicleClasses = repoVehicleClasses;
            _repoColor = repoColor;
            _repoVehCol = repoVehCol;
        }

        [HttpPost]
        public IActionResult Color(VehicleColor vehicleColor)
        {
            _repoVehCol.Store(vehicleColor);
            _repoVehCol.Commit();

            return RedirectToAction("Colors", new { id = vehicleColor.CarId });
        }

        [HttpGet]
        public IActionResult Colors(int id)
        {
            // All colors
            IList<Color> allColors = _repoColor.FindAll();
            // Vehicle colors
            IList<Color> vehicleColors = _repoColor.FindAllByCarId(id);

            var filtered = allColors.Where(c => !vehicleColors.Any(s => s.ColorId == c.ColorId));

            ViewBag.selectColors = new SelectList(filtered, "ColorId", "Name");
            ViewBag.colors = vehicleColors;

            VehicleColor vehicleColor = new VehicleColor()
            {
                Car = _repo.FindById(id)
            };

            return View(vehicleColor);
        }


        [HttpGet]
        public IActionResult Index(int? year)
        {
            IList<Car> cars = _repo.FindBy(s => (s.Year == year || year == null));

            return View(cars);

        }

        [HttpPost]
        public IActionResult Store(Car car)
        {
            _repo.Store(car);
            _repo.Commit();

            @TempData["msg"] = $"Veículo {car.Manufacturer} {car.Model} cadastrado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Store()
        {
            LoadManufacturers();
            LoadClasses();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadManufacturers();
            LoadClasses();
            return View(_repo.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            _repo.Update(car);
            _repo.Commit();

            @TempData["msg"] = $"Veículo atualizado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _repo.Destroy(id);
            _repo.Commit();

            @TempData["msg"] = $"Veículo removido com sucesso";

            return RedirectToAction("Index");
        }

        private void LoadManufacturers()
        {
            IList<Manufacturer> manufacturers = _repoManufacturer.FindAll();

            ViewBag.manufacturers = new SelectList(manufacturers, "ManufacturerId", "Name");
        }

        private void LoadClasses()
        {
            IList<VehicleType> vehicleTypes = _repoVehicleClasses.FindAll();

            ViewBag.classes = new SelectList(vehicleTypes, "VehicleTypeId", "Description");
        }
    }
}
