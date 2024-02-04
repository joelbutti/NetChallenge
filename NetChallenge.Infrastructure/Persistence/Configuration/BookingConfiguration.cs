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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DateTime)
                .IsRequired();

            builder.Property(c => c.Duration)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "Duration > 0");

            builder.Property(c => c.UserName)
                .IsRequired();

            builder.HasOne(c => c.Office)
                .WithMany(o => o.Bookings)
                .HasForeignKey(c => c.OfficeId)
                .IsRequired();

            builder.HasIndex(c => new { c.OfficeId, c.DateTime, c.Duration })
                .IsUnique();
        }
    }
}
