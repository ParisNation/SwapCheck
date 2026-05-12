using MediatR;
using SwapCheck.Application.DTOs;
using SwapCheck.Application.Interfaces;

namespace SwapCheck.Application.Queries.GetVehicles
{
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, List<VehicleDto>>
    {
      private readonly IVehicleRepository _repository;

        public GetVehiclesHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }   

        public async Task<List<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
          var vehicles = await _repository.GetAllVehiclesAsync();
          return vehicles.Select(v => new VehicleDto
          (v.Id, v.Make, v.Model, v.Year))
          .ToList();
        }
    }
}