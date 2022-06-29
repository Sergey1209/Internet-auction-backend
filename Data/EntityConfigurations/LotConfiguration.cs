using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.EntityConfigurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(30);
            builder.Property(x => x.Description).IsUnicode().HasMaxLength(1024);
            builder.Property(x => x.CategoryId).IsRequired().HasDefaultValue(1);
            builder.Property(x => x.OwnerId).IsRequired();

            builder.HasOne(a => a.Category).WithMany(b => b.Lots).OnDelete(DeleteBehavior.NoAction);

            List<Lot> lots = new List<Lot>();
            for (var i = 1; i < 12; i++)
            {
                lots.Add(new Lot() { Id = i, Name = $"lot {i}", CategoryId = 2, Description = $"Description {i}", OwnerId = i < 5 ? 1 : 2 });
            }

            lots.Add(new Lot() { Id = 12, Name = $"lot 13", CategoryId = 2, Description = $"Description 13", OwnerId = 1 });

            builder.HasData(lots);
        }
    }
}
