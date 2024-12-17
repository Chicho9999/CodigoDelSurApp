using CodigoDelSurApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodigoDelSurApp.Persistence
{
    public class CodigoDelSurDbContext : DbContext
    {
        public CodigoDelSurDbContext(DbContextOptions<CodigoDelSurDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            Guid userId = Guid.Parse("87ede418-e06b-4845-b8d1-0682a57f05f3");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System",
                }
            );
        }
    }
}
