using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;

namespace roadlovers.Repositories
{
    public interface IColorRepository
    {
        void Commit();

        void Store(Color color);
    }
}