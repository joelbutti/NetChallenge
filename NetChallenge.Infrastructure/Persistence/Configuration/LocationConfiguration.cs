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

            builder.OwnsOne(l => l.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired();

                name.HasIndex(n => n.Value).IsUnique();
            });

            builder.OwnsOne(l => l.Neighborhood, neighborhood =>
            {
                neighborhood.Property(n => n.Value)
                    .HasColumnName("Neighborhood")
                    .IsRequired();
            });

            builder.HasMany(l => l.Offices)
                .WithOne()
                .HasForeignKey(o => o.LocationId)
                .IsRequired();
        }
    }
}
