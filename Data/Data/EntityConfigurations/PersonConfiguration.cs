using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(30);
            builder.Property(x => x.Surname).IsRequired().IsUnicode().HasMaxLength(30);
        }
    }
}
