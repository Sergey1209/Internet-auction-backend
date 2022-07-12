using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(60);
            builder.Property(x => x.Description).IsUnicode().HasMaxLength(512);
            builder.Property(x => x.CategoryId).IsRequired().HasDefaultValue(1);
            builder.Property(x => x.OwnerId).IsRequired();

            builder.HasOne(a => a.Category).WithMany(b => b.Lots).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
