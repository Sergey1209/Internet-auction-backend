using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nickname).IsRequired().IsUnicode().HasMaxLength(30);

            builder.HasData(
                new Person() { Id = 1, Nickname = "Person1" },
                new Person() { Id = 2, Nickname = "Person2" },
                new Person() { Id = 3, Nickname = "Person3" }
            );
        }
    }
}
