using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwapCheck.Application.Queries.GetEngines;

namespace SwapCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EnginesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnginesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEngines()
        {
            var result = await _mediator.Send(new GetEnginesQuery());
            return Ok(result);
        }
    }
}