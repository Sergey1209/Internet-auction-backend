using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
