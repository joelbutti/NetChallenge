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
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired();

            builder.Property(l => l.Neighborhood)
                .IsRequired();

            builder.HasIndex(l => l.Name)
                .IsUnique();

            builder.HasMany(l => l.Offices)
                .WithOne()
                .HasForeignKey(o => o.LocationId)
                .IsRequired();
        }
    }
}
