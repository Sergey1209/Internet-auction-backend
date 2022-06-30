using Data.Entities;
using Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    /// <summary>
    /// Represents the context of an online auction.
    /// </summary>
    public class InternetAuctionDbContext : DbContext
    {
        /// <summary>
        /// Represents the data source of lots
        /// </summary>
        public DbSet<Lot> Lots { get; set; }
        /// <summary>
        /// Represents the lot category data source
        /// </summary>
        public DbSet<LotCategory> LotCategories { get; set; }
        /// <summary>
        /// Represents the auction data source
        /// </summary>
        public DbSet<Auction> Auctions { get; set; }
        /// <summary>
        /// Represents the files data source
        /// </summary>
        public DbSet<File> Files { get; set; }
        /// <summary>
        /// Represents the lot images data source
        /// </summary>
        public DbSet<LotImage> LotImages { get; set; }

        public InternetAuctionDbContext(DbContextOptions<InternetAuctionDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LotConfiguration());
            modelBuilder.ApplyConfiguration(new LotCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new LotImageConfiguration());
        }

    }
}
