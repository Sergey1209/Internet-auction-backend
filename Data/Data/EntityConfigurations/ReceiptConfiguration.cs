using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SellerId).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.LotId).IsRequired();
            builder.Property(x => x.OperationDate).IsRequired();

            builder.HasOne(a => a.Seller).WithMany(b => b.Receipts).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Customer).WithMany(b => b.Receipts).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Lot).WithOne(b => b.Receipt).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
