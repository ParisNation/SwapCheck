using SwapCheck.Domain.Entities;

namespace SwapCheck.Application.Interfaces
{
public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();
    }
}