using MediatR;
using AutoMapper;
using SwapCheck.Application.DTOs;
using SwapCheck.Application.Interfaces;

namespace SwapCheck.Application.Queries.GetCompatibleEngines
{
    public class GetCompatibleEnginesHandler : IRequestHandler<GetCompatibleEnginesQuery, List<SwapCompatibilityDto>>
    {
        private readonly ISwapCompatibilityRepository _repository;
        private readonly IMapper _mapper;

        public GetCompatibleEnginesHandler(ISwapCompatibilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SwapCompatibilityDto>> Handle(GetCompatibleEnginesQuery request, CancellationToken cancellationToken)
        {
            var compatibleEngines = await _repository.GetByVehicleIdAsync(request.VehicleId);
            return _mapper.Map<List<SwapCompatibilityDto>>(compatibleEngines);
        }
    }
}