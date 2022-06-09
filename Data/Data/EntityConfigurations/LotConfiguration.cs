using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().IsUnicode().HasMaxLength(1024);
            builder.Property(x => x.InitialPrice).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(a => a.Category).WithMany(b => b.Lots).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
