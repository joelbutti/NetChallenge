using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetChallenge.Domain.Entities;
using NetChallenge.Domain.ValueObjects;
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

            builder.OwnsOne(o => o.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired();

                name.HasIndex(n => n.Value).IsUnique();
            });

            builder.OwnsOne(o => o.MaxCapacity, maxCapacity =>
            {
                maxCapacity.Property(n => n.Value)
                    .HasColumnName("MaxCapacity")
                    .IsRequired();

                maxCapacity
                    .HasAnnotation("CheckConstraint", "MaxCapacity > 0");
            });

            builder.HasMany(l => l.Bookings)
                .WithOne()
                .HasForeignKey(o => o.OfficeId)
                .IsRequired();

            builder.Property(c => c.AvailableResources)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
