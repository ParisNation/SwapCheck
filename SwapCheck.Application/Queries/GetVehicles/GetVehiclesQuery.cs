using MediatR;
using SwapCheck.Application.DTOs;

namespace SwapCheck.Application.Queries.GetVehicles
{
    public class GetVehiclesQuery : IRequest<List<VehicleDto>>
    {      
    }
}