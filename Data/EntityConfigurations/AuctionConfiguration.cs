using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.EntityConfigurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BetValue).IsRequired().HasColumnType("money");
            builder.Property(x => x.InitialPrice).HasColumnType("money");
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.LotId).IsRequired();
            builder.Property(x => x.OperationDate).IsRequired();

            builder.HasIndex(x => x.LotId);

            builder.HasOne(a => a.Lot).WithOne(b => b.Auction).OnDelete(DeleteBehavior.Cascade);

            List<Auction> auctions = new List<Auction>();
            for (var i = 1; i < 100; i++)
            {
                var date = DateTime.Now.AddDays(i);
                auctions.Add(
                    new Auction()
                    {
                        Id = i + 200,
                        LotId = i,
                        InitialPrice = i * 10 + 12,
                        BetValue = i * 10 + 12,
                        CustomerId = i < 7 ? 1 : 2,
                        Deadline = date,
                        OperationDate = date
                    });
            }

            auctions.Add(
                new Auction()
                {
                    Id = 1100,
                    LotId = 1000,
                    InitialPrice = 10,
                    BetValue = 10,
                    CustomerId = 2,
                    Deadline = new DateTime(year: 2020, month: 1, day: 12),
                    OperationDate = new DateTime(year: 2021, month: 12, day: 12)
                });


            builder.HasData(auctions);
        }
    }
}
