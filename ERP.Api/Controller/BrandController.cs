using ERP.Application.Features.Brands.Requests.Commands;
using ERP.Application.Features.Brands.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.BrandModels;

namespace ERP.Api.Controller
{
    [Route("api/Brand")]
    [ApiController]
    [Authorize(Policy = AppPolicies.AllRoles)]
    public class BrandController : BaseController
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateBrandCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateBrandCommand command)
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
            => Handle(await _mediator.Send(new DeleteBrandCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<BrandDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "brands-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetBrandByIdQuery { Id = id }));

        [HttpGet("by-name/{name}")]
        [ProducesResponseType(typeof(Result<BrandDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "brands-tag" })]
        public async Task<IActionResult> GetByName(string name)
            => Handle(await _mediator.Send(new GetBrandByNameQuery { Name = name }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<BrandDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "brands-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetBrandsPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
