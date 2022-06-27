using Data.Entities;
using Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<PersonAuth> PeopleAuths { get; set; }
        public DbSet<Person> People { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> authOptions) : base(authOptions)
        {
            //Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonAuthConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Auth;Trusted_Connection=True;");
        }
    }
}
