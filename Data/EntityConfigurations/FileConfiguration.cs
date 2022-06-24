using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.HasIndex(x => x.Name);

            builder.HasData(
                new File() { Id = 1, Name = @"lotcategory1.png" },
                new File() { Id = 2, Name = @"lotcategory2.png" },
                new File() { Id = 3, Name = @"lotcategory3.png" },

                new File() { Id = 11, Name = @"lot1.jpg" },
                new File() { Id = 12, Name = @"lot2.jpg" },
                new File() { Id = 13, Name = @"lot3.jpg" }
            );
        }
    }
}
