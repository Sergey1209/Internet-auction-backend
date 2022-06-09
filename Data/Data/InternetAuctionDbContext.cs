using Data.Data.EntityConfigurations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class InternetAuctionDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<LotCategory> LotCategories { get; set; }
        public DbSet<PersonAuth> PersonAuths { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public InternetAuctionDbContext()
        {
            Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonAuthConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            modelBuilder.ApplyConfiguration(new LotConfiguration());
            modelBuilder.ApplyConfiguration(new LotCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=InternetAuction;Trusted_Connection=True;");
        }
    }
}
