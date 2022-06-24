using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.EntityConfigurations
{
    public class LotImageConfiguration : IEntityTypeConfiguration<LotImage>
    {
        public void Configure(EntityTypeBuilder<LotImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LotId).IsRequired();
            builder.Property(x => x.FileId).IsRequired();

            builder.HasIndex(x => new { x.LotId, x.FileId});

            builder.HasOne(x => x.File).WithMany(b => b.LotImages).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Lot).WithMany(b => b.LotImages).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new LotImage() { Id = 1, LotId = 1, FileId = 11 },
                new LotImage() { Id = 2, LotId = 1, FileId = 12 },
                new LotImage() { Id = 3, LotId = 2, FileId = 13 }
            );
        }
    }
}
