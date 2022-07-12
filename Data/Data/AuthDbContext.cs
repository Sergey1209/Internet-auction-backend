using Data.Entities;
using Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    /// <summary>
    /// Represents the user store context
    /// </summary>
    public class AuthDbContext : DbContext
    {
        /// <summary>
        /// Represents the data source of user authentication data
        /// </summary>
        public DbSet<PersonAuth> PeopleAuths { get; set; }

        /// <summary>
        /// Represents the data source of users' personal data
        /// </summary>
        public DbSet<Person> People { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> authOptions) : base(authOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonAuthConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            FillDataBase(modelBuilder);
        }

        private void FillDataBase(ModelBuilder modelBuilder)
        {
            for (var i = 1; i < 5; i++)
            {
                modelBuilder.Entity<Person>().HasData(
                    new Person()
                    {
                        Id = i,
                        Nickname = $"Person{i}"
                    });

                modelBuilder.Entity<PersonAuth>().HasData(
                    new PersonAuth()
                    {
                        Email = i == 1 ? "admin@auction.com" : $"user{i}@auction.com",
                        Password = "1",
                        Role = i == 1 ? Role.Administrator : Role.UnRegisteredUser,
                        PersonId = i
                    });
            }
        }
    }
}
