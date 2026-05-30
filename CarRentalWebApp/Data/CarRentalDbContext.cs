using CarRentalWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApp.Data
{
    public class CarRentalDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
        }

        public DbSet<CarModel> Cars { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rental - Customers ilişkisi
            modelBuilder.Entity<RentalModel>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Rental - Cars ilişkisi
            modelBuilder.Entity<RentalModel>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CarModel>()
                .Property(c => c.DailyPrice)
                .HasPrecision(18, 2);
        }
    }
}
