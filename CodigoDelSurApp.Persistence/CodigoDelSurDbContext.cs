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

            Guid userId = Guid.Parse("87ede418-e06b-4845-b8d1-0682a57f05f3");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    FirstName = "Admin",
                    Email = "Adming@hotmail.com",
                    LastName = "",
                    Username = "Admin",
                    Password = "??$?<??{j??\u007f]??\u0001?vlH\\?]?????s3]o",
                }
            );

            modelBuilder.Entity<UserPreference>().HasData(
                new UserPreference
                {
                    UserId = userId,
                    PreferenceKey = "Abv",
                    PreferenceValue = "Desc"
                }
            );
        }
    }
}
