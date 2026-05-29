using SwapCheck.Domain.Entities;

namespace SwapCheck.Application.Interfaces
{
    public interface ISwapCompatibilityRepository
    {
        Task<List<SwapCompatibility>> GetByVehicleIdAsync(Guid vehicleId);
        Task<SwapCompatibility?> GetByVehicleAndEngineAsync(Guid vehicleId, Guid engineId);
    }
}