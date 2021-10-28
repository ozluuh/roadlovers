using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadlovers.Models;
using roadlovers.Persistence;
using roadlovers.Repositories;

namespace roadlovers.Repositories
{
    public class CarRepository : ICarRepository
    {
        private FactoryContext _context;

        public CarRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Destroy(int id)
        {
            Car car = _context.Cars.Find(id);
            _context.Cars.Remove(car);
        }

        public IList<Car> FindAll()
        {
            return _context.Cars.ToList();
        }

        public IList<Car> FindBy(Expression<Func<Car, bool>> filter)
        {
            return _context
                        .Cars
                        .Where(filter)
                        .Include(e => e.Manufacturer)
                        .Include(e => e.VehicleType)
                    .ToList()
                    ;
        }

        public Car FindById(int id)
        {
            return _context
                        .Cars
                        .Where(c => c.CarId == id)
                        .Include(m => m.Manufacturer)
                        .Include(c => c.VehicleType)
                        .FirstOrDefault()
                    ;
        }

        public void Store(Car car)
        {
            _context.Cars.Add(car);
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
        }
    }
}