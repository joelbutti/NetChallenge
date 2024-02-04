using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Infrastructure.Persistence.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.MaxCapacity)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "MaxCapacity > 0");

            builder.HasMany(l => l.Bookings)
                .WithOne(o => o.Office)
                .HasForeignKey(o => o.OfficeId)
                .IsRequired();

            builder.HasIndex(c => new { c.LocationId, c.Name }).IsUnique();

            builder.Property(c => c.AvailableResources)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
