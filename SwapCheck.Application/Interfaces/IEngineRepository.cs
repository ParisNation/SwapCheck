using SwapCheck.Domain.Entities;

namespace SwapCheck.Application.Interfaces
{
    public interface IEngineRepository
    {
        Task<List<Engine>> GetAllEnginesAsync();
    }
}