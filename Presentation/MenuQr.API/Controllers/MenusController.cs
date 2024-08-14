using MediatR;
using MenuQr.Application.Features.Commands.Menu.Create;
using MenuQr.Application.Features.Queries.Menu.GetAll;
using MenuQr.Application.Features.Queries.Menu.GetMenuById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuQr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu([FromBody] CreateMenuCommandRequest createMenuCommandRequest)
        {
            CreateMenuCommandResponse response = await _mediator.Send(createMenuCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenus([FromQuery] GetAllMenuQueryRequest getAllMenuQueryRequest)
        {
            GetAllMenuQueryResponse response = await _mediator.Send(getAllMenuQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMenuById([FromRoute]GetMenuByIdQueryRequest request)
        {
            GetMenuByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
