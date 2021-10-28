using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;
using roadlovers.Persistence;

namespace roadlovers.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private FactoryContext _context;

        public VehicleTypeRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<VehicleType> FindAll()
        {
            return _context.Classes.ToList();
        }

        public VehicleType FindById(int id)
        {
            return _context
                        .Classes
                        .Where(c => c.VehicleTypeId == id)
                        .FirstOrDefault()
                    ;
        }

        public void Store(VehicleType type)
        {
            _context.Classes.Add(type);
        }
    }
}