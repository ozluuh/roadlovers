using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;
using roadlovers.Persistence;

namespace roadlovers.Repositories
{
    public class VehicleColorRepository : IVehicleColorRepository
    {
        private FactoryContext _context;

        public VehicleColorRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Store(VehicleColor vehicleColor)
        {
            _context.VehiclesColors.Add(vehicleColor);
        }
    }
}