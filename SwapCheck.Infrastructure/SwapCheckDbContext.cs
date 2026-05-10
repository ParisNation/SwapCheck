using Microsoft.EntityFrameworkCore;
using SwapCheck.Domain.Entities;

namespace SwapCheck.Infrastructure;
public class SwapCheckDbContext : DbContext
{
    public SwapCheckDbContext(DbContextOptions<SwapCheckDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<SwapCompatibility> SwapCompatibilities { get; set; }
}