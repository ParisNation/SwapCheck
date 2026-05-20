using Microsoft.EntityFrameworkCore;
using SwapCheck.Application.Interfaces;
using SwapCheck.Domain.Entities;

namespace SwapCheck.Infrastructure.Repositories
{
    public class SwapCompatibilityRepository : ISwapCompatibilityRepository
    {
        private readonly SwapCheckDbContext _context;

        public SwapCompatibilityRepository(SwapCheckDbContext context)
        {
            _context = context;
        }

        public async Task<List<SwapCompatibility>> GetByVehicleIdAsync(Guid vehicleId)
        {
           return await _context.SwapCompatibilities
            .Where(s => s.VehicleId == vehicleId)
            .Include(s => s.Engine)
            .ToListAsync();

        }
    }
}