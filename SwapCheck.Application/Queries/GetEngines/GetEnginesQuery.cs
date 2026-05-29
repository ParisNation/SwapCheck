using MediatR;
using SwapCheck.Application.DTOs;

namespace SwapCheck.Application.Queries.GetEngines
{
    public class GetEnginesQuery : IRequest<List<EngineDto>>
    {
    }
}