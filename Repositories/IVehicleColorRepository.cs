using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;

namespace roadlovers.Repositories
{
    public interface IVehicleColorRepository
    {
        void Store(VehicleColor vehicleColor);
        void Commit();
    }
}