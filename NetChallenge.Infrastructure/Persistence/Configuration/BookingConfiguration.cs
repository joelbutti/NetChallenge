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

            builder.OwnsOne(o => o.Duration, duration =>
            {
                duration.Property(n => n.Value)
                    .HasColumnName("Duration")
                    .IsRequired();

                duration
                    .HasAnnotation("CheckConstraint", "Duration > 0");
            });

            builder.OwnsOne(l => l.UserName, userName =>
            {
                userName.Property(n => n.Value)
                    .HasColumnName("UserName")
                    .IsRequired();
            });
        }
    }
}
