using Data.EntityConfigurations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{ 
    public class InternetAuctionDbContext : DbContext
    {
        public DbSet<Lot> Lots { get; set; }
        public DbSet<LotCategory> LotCategories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<LotImage> LotImages { get; set; }

        public InternetAuctionDbContext(DbContextOptions<InternetAuctionDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LotConfiguration());
            modelBuilder.ApplyConfiguration(new LotCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new LotImageConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=InternetAuction;Trusted_Connection=True;");
        }
    }
}
