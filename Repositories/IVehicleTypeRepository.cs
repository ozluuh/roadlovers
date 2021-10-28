using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;

namespace roadlovers.Repositories
{
    public interface IVehicleTypeRepository
    {
        void Commit();

        void Store(VehicleType type);

        IList<VehicleType> FindAll();

        VehicleType FindById(int id);
    }
}