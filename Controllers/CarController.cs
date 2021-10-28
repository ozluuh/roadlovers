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

        public CarController(ICarRepository repo, IManufacturerRepository repoManufacturer, IVehicleTypeRepository repoVehicleClasses)
        {
            _repo = repo;
            _repoManufacturer = repoManufacturer;
            _repoVehicleClasses = repoVehicleClasses;
        }

        // private static List<Car> _carros = new List<Car>() {
        //     new Car(1,1963, "Corvette (C2)", 55000d, VehicleType.Muscle, Manufacturer.Chevrolet),
        //     new Car(2,2006, "Cobalt SS", 20000d, VehicleType.Sports, Manufacturer.Chevrolet),
        //     new Car(3,2009, "CLS55 AMG", 270000d, VehicleType.Luxury, Manufacturer.Mercedes_Benz),
        //     new Car(4,1993, "Diablo", 138000d, VehicleType.Exotic, Manufacturer.Lamborghini)
        // };




        [HttpGet]
        public IActionResult Index(int? year)
        {
            IList<Car> cars = _repo.FindAll();

            if (year == null)
            {
                ViewBag.filter = false;
                return View(cars);
            }

            ViewBag.filter = true;
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
