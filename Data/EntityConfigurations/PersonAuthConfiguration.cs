using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    internal class PersonAuthConfiguration : IEntityTypeConfiguration<PersonAuth>
    {
        public void Configure(EntityTypeBuilder<PersonAuth> builder)
        {
            builder.HasKey(x => x.PersonId).IsClustered(false);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Role).IsRequired().HasDefaultValue(Role.RegisteredUser);
            builder.Property(x => x.PersonId).IsRequired();

            builder.HasOne(a => a.Person).WithOne(b => b.PersonAuth).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.PersonId).IsUnique(true);
        }
    }
}
