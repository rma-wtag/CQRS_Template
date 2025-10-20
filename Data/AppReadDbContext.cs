using CQRSDemo1.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo1.Data
{
    public class AppReadDbContext : DbContext
    {
        public AppReadDbContext(DbContextOptions<AppReadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(p => p.Id)
                .ValueGeneratedNever();
        }

        public DbSet<Player> Players { get; set; }

    }
}
