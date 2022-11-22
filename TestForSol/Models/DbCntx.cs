using Microsoft.EntityFrameworkCore;

namespace TestForSol.Models
{
    public class DbCntx : DbContext
    {
        public DbCntx(DbContextOptions<DbCntx> options) : base (options)
        {}

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasAlternateKey(o => new { o.Number, o.ProviderId});

            modelBuilder.Entity<Provider>().HasData(
                new Provider {Id = 1, Name = "First"},
                new Provider {Id = 2, Name = "Second"},
                new Provider {Id = 3, Name = "Third"});
        }       
    }
}
