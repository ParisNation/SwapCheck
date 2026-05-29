using MediatR;
using SwapCheck.Application.DTOs;

namespace SwapCheck.Application.Queries.GetCompatibilityByVehicleAndEngine
{
    public class GetCompatibilityByVehicleAndEngineQuery : IRequest<SwapCompatibilityDto?>
    {
        public Guid VehicleId { get; set; }
        public Guid EngineId { get; set; }
    }
}