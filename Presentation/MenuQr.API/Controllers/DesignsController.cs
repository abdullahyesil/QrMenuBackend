using MediatR;
using MenuQr.Application.Features.Commands.Designs.Create;
using MenuQr.Application.Features.Queries.Designs.GetDesignsById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuQr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> addDesigns([FromBody] CreateDesignsCommandRequest createDesignsCommandRequest)
        {

            CreateDesignsCommandResponse response = await _mediator.Send(createDesignsCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> getById([FromRoute] GetDesignsByIdQueryRequest getDesignsById)
        {
            GetDesignsByIdQueryResponse response = await _mediator.Send(getDesignsById);
            return Ok(response);
        }
    }
}
