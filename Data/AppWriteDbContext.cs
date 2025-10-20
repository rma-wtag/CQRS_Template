using CQRSDemo1.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo1.Data
{
    public class AppWriteDbContext : DbContext
    {
        public AppWriteDbContext(DbContextOptions<AppWriteDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }

    }
}
