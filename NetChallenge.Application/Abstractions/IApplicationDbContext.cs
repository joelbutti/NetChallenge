using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Office> Offices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
