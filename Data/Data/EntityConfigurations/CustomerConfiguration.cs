using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.EntityConfigurations 
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PersonId).IsRequired();
            builder.HasOne(a => a.Person).WithOne(b => b.Customer).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
