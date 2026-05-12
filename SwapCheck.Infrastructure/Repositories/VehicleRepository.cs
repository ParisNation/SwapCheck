using Microsoft.EntityFrameworkCore;
using SwapCheck.Application.Interfaces;
using SwapCheck.Domain.Entities;

namespace SwapCheck.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SwapCheckDbContext _context;

        public VehicleRepository(SwapCheckDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }
    }
}