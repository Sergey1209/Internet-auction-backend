using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.EntityConfigurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(30);
            builder.Property(x => x.Description).IsUnicode().HasMaxLength(1024);
            builder.Property(x => x.InitialPrice).HasColumnType("money");
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.OwnerId).IsRequired();

            builder.HasOne(a => a.Category).WithMany(b => b.Lots).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Lot() { Id = 1, Name = "lot 1", InitialPrice = 12, CategoryId = 1, Description = "Description", Deadline=DateTime.Now.AddDays(100), OwnerId = 1},
                new Lot() { Id = 2, Name = "lot 2", CategoryId = 1, Description = "Description", Deadline = DateTime.Now.AddDays(100), OwnerId = 1 },
                new Lot() { Id = 3, Name = "lot 3", InitialPrice = 11111, CategoryId = 2, Description = "Description", Deadline = DateTime.Now.AddDays(100), OwnerId = 2 }
            );
        }
    }
}
