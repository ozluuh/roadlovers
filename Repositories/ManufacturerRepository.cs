using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;
using roadlovers.Persistence;
using roadlovers.Repositories;

namespace roadlovers.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private FactoryContext _context;

        public ManufacturerRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Manufacturer> FindAll()
        {
            return _context.Manufacturers.ToList();
        }

        public void Store(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
        }

        public void Update(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(manufacturer);
        }
    }
}