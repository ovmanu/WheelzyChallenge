using Microsoft.EntityFrameworkCore;
using WheelzyChallenge.Domain.Entities;
using WheelzyChallenge.Infrastructure.Persistence.Configurations;

namespace WheelzyChallenge.Infrastructure.Persistence
{
    public class WheelzyDbContext : DbContext
    {
        public WheelzyDbContext(DbContextOptions<WheelzyDbContext> options)
            : base(options) { }

        public DbSet<Buyer> Buyers { get; set; } = null!;
        public DbSet<BuyerZipQuote> BuyerZipQuotes { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarQuote> CarQuotes { get; set; } = null!;
        public DbSet<CarStatusHistory> CarStatusHistories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerZipQuoteConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarQuoteConfiguration());
            modelBuilder.ApplyConfiguration(new CarStatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
