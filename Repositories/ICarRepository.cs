using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using roadlovers.Models;

namespace roadlovers.Repositories
{
    public interface ICarRepository
    {
        void Store(Car car);

        void Update(Car car);

        void Destroy(int id);

        IList<Car> FindAll();

        void Commit();

        Car FindById(int id);

        IList<Car> FindBy(Expression<Func<Car, bool>> filter);
    }
}