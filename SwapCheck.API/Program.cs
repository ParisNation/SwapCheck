using Microsoft.EntityFrameworkCore;
using SwapCheck.Application.Queries.GetVehicles;
using SwapCheck.Application.Interfaces;
using SwapCheck.Infrastructure.Repositories;
using SwapCheck.Infrastructure;
using SwapCheck.Infrastructure.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SwapCheckDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblies(typeof(GetVehiclesQuery).Assembly));

builder.Services.AddControllers();
builder.Services.AddScoped<SwapCheckSeeder>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SwapCheckSeeder>();
    await seeder.SeedAsync();
}

app.Run();