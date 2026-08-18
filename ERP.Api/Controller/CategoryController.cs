using ERP.Application.Features.Categories.Requests.Commands;
using ERP.Application.Features.Categories.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.CategoryModels;

namespace ERP.Api.Controller
{
    [Route("api/Category")]
    [ApiController]
    [Authorize(Policy = AppPolicies.AllRoles)]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteCategoryCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<CategoryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "categories-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetCategoryByIdQuery { Id = id }));

        [HttpGet("by-name/{name}")]
        [ProducesResponseType(typeof(Result<CategoryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "categories-tag" })]
        public async Task<IActionResult> GetByName(string name)
            => Handle(await _mediator.Send(new GetCategoryByNameQuery { Name = name }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<CategoryDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "categories-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetCategoriesPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
