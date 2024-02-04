using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Infrastructure.Persistence;
using System.Globalization;

namespace NetChallenge.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
