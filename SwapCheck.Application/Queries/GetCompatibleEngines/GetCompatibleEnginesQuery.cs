using MediatR;
using SwapCheck.Application.DTOs;

namespace SwapCheck.Application.Queries.GetCompatibleEngines
{
    public class GetCompatibleEnginesQuery : IRequest<List<SwapCompatibilityDto>>
    {
        public Guid VehicleId { get; set; }
    }
}