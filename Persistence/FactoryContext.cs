using Microsoft.EntityFrameworkCore;
using roadlovers.Models;

namespace roadlovers.Persistence
{
    public class FactoryContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public FactoryContext(DbContextOptions options) : base(options){ }
    }
}