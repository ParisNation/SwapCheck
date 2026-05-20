using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}