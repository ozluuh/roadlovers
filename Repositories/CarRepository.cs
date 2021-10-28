using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Car FindById(int id)
        {
            return _context
                        .Cars
                        .Where(c => c.CarId == id)
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