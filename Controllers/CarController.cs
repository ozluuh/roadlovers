using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using roadlovers.Models;
using roadlovers.Persistence;

namespace roadlovers.Controllers
{
    public class CarController : Controller
    {
        private FactoryContext _context;

        public CarController(FactoryContext context)
        {
            this._context = context;
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
            if (year == null)
            {
                ViewBag.filter = false;
                return View(_context.Cars.ToList());
            }

            ViewBag.filter = true;

            return View(_context.Cars.ToList());

        }

        [HttpPost]
        public IActionResult Store(Car car)
        {
            _context.Cars.Add(car);

            @TempData["msg"] = $"Veículo {car.Manufacturer} {car.Model} cadastrado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Store()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // var car = _context.Cars.Find(car => car.);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            // int i = _cars.FindIndex(c => c.Id == car.Id);

            // _cars[i] = car;

            @TempData["msg"] = $"Veículo atualizado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            // var car = _cars.Find(c => c.Id == id);

            // _cars.RemoveAll(c => c.Id == id);

            // @TempData["msg"] = $"Veículo {car.Manufacturer} {car.Model} removido com sucesso";

            return RedirectToAction("Index");
        }
    }
}
