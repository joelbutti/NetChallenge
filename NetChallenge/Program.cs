using Microsoft.AspNetCore.Localization;
using NetChallenge.API.Bootstrap;
using NetChallenge.API.Extensions;
using NetChallenge.Application.Bootstrap;
using NetChallenge.Infrastructure.Bootstrap;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
