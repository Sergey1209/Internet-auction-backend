using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PersonId).IsRequired();
            builder.HasOne(a => a.Person).WithOne(b => b.Seller).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
