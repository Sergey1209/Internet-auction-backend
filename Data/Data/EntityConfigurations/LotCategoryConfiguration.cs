using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    public class LotCategoryConfiguration : IEntityTypeConfiguration<LotCategory>
    {
        public void Configure(EntityTypeBuilder<LotCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(128);
        }
    }
}
