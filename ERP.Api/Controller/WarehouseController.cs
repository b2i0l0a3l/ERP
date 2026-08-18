using ERP.Application.Features.Warehouses.Requests.Commands;
using ERP.Application.Features.Warehouses.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.WarehouseModels;

namespace ERP.Api.Controller
{
    [Route("api/Warehouse")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class WarehouseController : BaseController
    {
        private readonly IMediator _mediator;
        public WarehouseController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Authorize(Policy = AppPolicies.AdminOnly)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateWarehouseCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [Authorize(Policy = AppPolicies.AdminOnly)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateWarehouseCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AppPolicies.AdminOnly)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteWarehouseCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<WarehouseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "warehouses-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetWarehouseByIdQuery { Id = id }));

        [HttpGet("by-name/{name}")]
        [ProducesResponseType(typeof(Result<WarehouseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "warehouses-tag" })]
        public async Task<IActionResult> GetByName(string name)
            => Handle(await _mediator.Send(new GetWarehouseByNameQuery { Name = name }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<WarehouseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "warehouses-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetWarehousesPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
