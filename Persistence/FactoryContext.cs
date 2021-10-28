using Microsoft.EntityFrameworkCore;
using roadlovers.Models;

namespace roadlovers.Persistence
{
    public class FactoryContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleType> Classes { get; set; }

        public FactoryContext(DbContextOptions options) : base(options){ }
    }
}