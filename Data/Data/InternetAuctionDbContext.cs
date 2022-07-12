using Data.Entities;
using Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
            FillDataBase(modelBuilder);
        }

        private void FillDataBase(ModelBuilder builder)
        {
            builder.Entity<File>().HasData(
                new File() { Id = 1, Name = @"lotcategory1.png" },
                new File() { Id = 2, Name = @"lotcategory2.png" },
                new File() { Id = 3, Name = @"lotcategory3.png" },

                new File() { Id = 11, Name = @"lot1.jpg" },
                new File() { Id = 12, Name = @"lot2.jpg" },
                new File() { Id = 13, Name = @"lot3.jpg" }
            );

            builder.Entity<LotCategory>().HasData(
                new LotCategory() { Id = 1, Name = "Other", FileId = 1 },
                new LotCategory() { Id = 2, Name = "Category 2", FileId = 2 },
                new LotCategory() { Id = 3, Name = "Category 3", FileId = 3 }
            );

            List<Lot> lots = new List<Lot>();
            List<Auction> auctions = new List<Auction>();

            var rnd = new Random();
            var startedDate = new DateTime(year: 2022, month: 6, day: 1);

            for (var lotId = 1; lotId < 500; lotId++)
            {
                var categoryRnd = rnd.Next(1, 4);
                var OwnerRnd = rnd.Next(2, 4);

                lots.Add(new Lot()
                {
                    Id = lotId,
                    Name = $"lot {lotId}, categoryId: {categoryRnd}",
                    CategoryId = categoryRnd,
                    Description = $"Description: lotid: {lotId}, category: {categoryRnd}",
                    OwnerId = OwnerRnd
                });

                var dateCreated = startedDate.AddDays(0.4 * lotId);
                var priceRnd = rnd.Next(10, 900);
                var offsetDeadLineRnd = rnd.Next(1, 30);

                auctions.Add(new Auction()
                {
                    Id = lotId + 1000,
                    LotId = lotId,
                    InitialPrice = priceRnd,
                    BetValue = priceRnd,
                    CustomerId = OwnerRnd,
                    Deadline = dateCreated.AddDays(offsetDeadLineRnd),
                    OperationDate = dateCreated
                });
            }

            builder.Entity<Lot>().HasData(lots);
            builder.Entity<Auction>().HasData(auctions);

            builder.Entity<LotImage>().HasData(
               new LotImage() { Id = 1, LotId = 499, FileId = 11 },
               new LotImage() { Id = 2, LotId = 499, FileId = 12 },
               new LotImage() { Id = 3, LotId = 498, FileId = 13 }
           );
        }

    }
}
