using CodigoDelSurApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodigoDelSurApp.Persistence
{
    public class CodigoDelSurDbContext : DbContext
    {
        public CodigoDelSurDbContext()
        {
        }

        public CodigoDelSurDbContext(DbContextOptions<CodigoDelSurDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }
}
