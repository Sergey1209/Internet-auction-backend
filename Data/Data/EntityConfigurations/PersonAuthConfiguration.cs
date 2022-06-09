using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations
{
    internal class PersonAuthConfiguration : IEntityTypeConfiguration<PersonAuth>
    {
        public void Configure(EntityTypeBuilder<PersonAuth> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PersonId).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(60);

            builder.HasOne(a => a.Person).WithOne(b => b.PersonAuth).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
