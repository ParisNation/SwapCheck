using MediatR;
using AutoMapper;
using SwapCheck.Application.DTOs;
using SwapCheck.Application.Interfaces;

namespace SwapCheck.Application.Queries.GetCompatibilityByVehicleAndEngine
{
    public class GetCompatibilityByVehicleAndEngineHandler : IRequestHandler<GetCompatibilityByVehicleAndEngineQuery, SwapCompatibilityDto?>
    {
        private readonly ISwapCompatibilityRepository _repository;
        private readonly IMapper _mapper;
        
        public GetCompatibilityByVehicleAndEngineHandler(ISwapCompatibilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SwapCompatibilityDto?> Handle(GetCompatibilityByVehicleAndEngineQuery request, CancellationToken cancellationToken)
        {
            var compatibleVehiclesAndEngines = await _repository.GetByVehicleAndEngineAsync(request.VehicleId, request.EngineId);
            if (compatibleVehiclesAndEngines == null) return null;
            return _mapper.Map<SwapCompatibilityDto>(compatibleVehiclesAndEngines);
        }
    }
}