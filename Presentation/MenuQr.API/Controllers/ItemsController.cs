using MediatR;
using MenuQr.Application.Features.Commands.Items.Create;
using MenuQr.Application.Features.Queries.Items.GetItemsById;
using MenuQr.Application.Features.Queries.Items.GetItemsByMenuId;
using MenuQr.Application.Features.Queries.Menu.GetMenuById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuQr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatedItems([FromBody] CreateItemsCommandRequest createItemsCommandRequest)
        {
            CreateItemsCommandResponse response = await _mediator.Send(createItemsCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetItemsByIdQueryRequest request)
        {
            GetItemsByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("Menu/{MenuId}")]
        public async Task<IActionResult> GetByMenuId([FromRoute]GetItemsByMenuIdQueryRequest request)
        {
            GetItemsByMenuIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
