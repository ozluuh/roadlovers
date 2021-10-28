using Microsoft.EntityFrameworkCore;
using roadlovers.Models;

namespace roadlovers.Persistence
{
    public class FactoryContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleType> Classes { get; set; }
        public DbSet<VehicleColor> VehiclesColors { get; set; }

        public DbSet<Color> Colors { get; set; }

        public FactoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VehicleColor>()
                .HasKey(k => new { k.CarId, k.ColorId });

            modelBuilder
                .Entity<VehicleColor>()
                .HasOne(k => k.Car)
                .WithMany(k => k.VehiclesColors)
                .HasForeignKey(k => k.CarId)
            ;

            modelBuilder
                .Entity<VehicleColor>()
                .HasOne(k => k.Color)
                .WithMany(k => k.VehiclesColors)
                .HasForeignKey(k => k.ColorId)
            ;

            base.OnModelCreating(modelBuilder);
        }
    }
}