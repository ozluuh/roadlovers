using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;

namespace roadlovers.Repositories
{
    public interface IManufacturerRepository
    {
        void Commit();

        void Store(Manufacturer manufacturer);

        void Update(Manufacturer manufacturer);

        IList<Manufacturer> FindAll();
    }
}