using MediatR;
using AutoMapper;
using SwapCheck.Application.DTOs;
using SwapCheck.Application.Interfaces;

namespace SwapCheck.Application.Queries.GetVehicles
{
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, List<VehicleDto>>
    {
      private readonly IVehicleRepository _repository;
      private readonly IMapper _mapper;

        public GetVehiclesHandler(IVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   

        public async Task<List<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
          var vehicles = await _repository.GetAllVehiclesAsync();
          return _mapper.Map<List<VehicleDto>>(vehicles);
        }
    }
}