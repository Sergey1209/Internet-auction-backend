using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class LotCategoryConfiguration : IEntityTypeConfiguration<LotCategory>
    {
        public void Configure(EntityTypeBuilder<LotCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(60);
            builder.Property(x => x.FileId);

            builder.HasOne(a => a.File).WithOne(b => b.LotCategory).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new LotCategory() { Id = 1, Name = "Miscellaneous", FileId = 1 },
                new LotCategory() { Id = 2, Name = "Category 2", FileId = 2 },
                new LotCategory() { Id = 3, Name = "Category 3", FileId = 3 }
            );
        }
    }
}
