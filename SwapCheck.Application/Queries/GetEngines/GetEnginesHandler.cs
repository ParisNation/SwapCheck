using MediatR;
using AutoMapper;
using SwapCheck.Application.DTOs;
using SwapCheck.Application.Interfaces;

namespace SwapCheck.Application.Queries.GetEngines
{
    public class GetEnginesHandler : IRequestHandler<GetEnginesQuery, List<EngineDto>>
    {
        private readonly IEngineRepository _repository;
        private readonly IMapper _mapper;

        public GetEnginesHandler(IEngineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EngineDto>> Handle(GetEnginesQuery request, CancellationToken cancellationToken)
        {
            var engines = await _repository.GetAllEnginesAsync();
            return _mapper.Map<List<EngineDto>>(engines);
        }
    }
}