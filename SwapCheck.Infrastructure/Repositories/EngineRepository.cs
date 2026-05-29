using Microsoft.EntityFrameworkCore;
using SwapCheck.Application.Interfaces;
using SwapCheck.Domain.Entities;

namespace SwapCheck.Infrastructure.Repositories
{
    public class EngineRepository : IEngineRepository
    {
        private readonly SwapCheckDbContext _context;

        public EngineRepository(SwapCheckDbContext context)
        {
            _context = context;
        }

        public async Task<List<Engine>> GetAllEnginesAsync()
        {
            return await _context.Engines.ToListAsync();
        }
    }
}