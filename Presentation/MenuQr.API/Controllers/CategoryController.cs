using MediatR;
using MenuQr.Application.Features.Commands.Category.Create;
using MenuQr.Application.Features.Queries.Category;
using MenuQr.Application.Features.Queries.Menu.GetMenuById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuQr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> addCategory([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest) {

            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpGet("{MenuId}")]
        public async Task<IActionResult> getCategoryByMenuId([FromRoute] GetCategoryByMenuIdRequest getCategoryByMenuIdRequest)
        {
            GetCategoryByMenuIdResponse response = await _mediator.Send(getCategoryByMenuIdRequest);
            return Ok(response);
        }
    }
}
