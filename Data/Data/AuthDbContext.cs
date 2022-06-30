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
        }

    }
}
