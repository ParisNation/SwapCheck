using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwapCheck.Application.Queries.GetCompatibilityByVehicleAndEngine;
using SwapCheck.Application.Queries.GetCompatibleEngines;

namespace SwapCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CompatibilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompatibilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetCompatibleEngine(Guid vehicleId)
        {
            var results = await _mediator.Send(new GetCompatibleEnginesQuery{VehicleId = vehicleId});
            return Ok(results);
        }

        [HttpGet("{vehicleId}/{engineId}")]
        public async Task<IActionResult> GetCompatibleVehiclesAndEngines(Guid vehicleId, Guid engineId)
        {
            var results = await _mediator.Send(new GetCompatibilityByVehicleAndEngineQuery{VehicleId = vehicleId, EngineId = engineId});
            if (results == null) return NotFound("No compatibility record found for this combination.");
            return Ok(results);
        }
    }
}