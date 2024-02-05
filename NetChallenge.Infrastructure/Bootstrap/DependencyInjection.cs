using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Application.Common.Interfaces;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Domain.Primitives;
using NetChallenge.Infrastructure.Persistence;
using NetChallenge.Infrastructure.Persistence.Repositories;
using NetChallenge.Infrastructure.Services;

namespace NetChallenge.Infrastructure.Bootstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IApplicationDbContext>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IOfficeRentalService, OfficeRentalService>();

            return services;
        }
    }
}
