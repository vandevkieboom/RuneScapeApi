using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Boss> Bosses => Set<Boss>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<UniqueItem> UniqueItems => Set<UniqueItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAppData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
