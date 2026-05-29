using Microsoft.EntityFrameworkCore;
using SwapCheck.Application.Queries.GetVehicles;
using SwapCheck.Application.Interfaces;
using SwapCheck.Infrastructure.Repositories;
using SwapCheck.Infrastructure;
using SwapCheck.Infrastructure.Data;
using SwapCheck.Application.Validators;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter()
        );
    });

builder.Services.AddAutoMapper(typeof(SwapCheck.Application.Mappings.MappingProfile).Assembly);

builder.Services.AddDbContext<SwapCheckDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IEngineRepository, EngineRepository>();
builder.Services.AddScoped<ISwapCompatibilityRepository, SwapCompatibilityRepository>();
builder.Services.AddValidatorsFromAssembly(typeof(GetCompatibleEnginesValidator).Assembly);
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblies(typeof(GetVehiclesQuery).Assembly));
builder.Services.AddScoped<SwapCheckSeeder>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowReact");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SwapCheckSeeder>();
    await seeder.SeedAsync();
}

app.Run();