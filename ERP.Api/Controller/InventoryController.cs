using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Application.Features.Inventories.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;

namespace ERP.Api.Controller
{
    [Route("api/Inventory")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class InventoryController : BaseController
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateInventoryCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateInventoryCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteInventoryCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 60, Tags = new[] { "inventories-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetInventoryByIdQuery { Id = id }));

        [HttpGet("by-product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 60, Tags = new[] { "inventories-tag" })]
        public async Task<IActionResult> GetByProductId(int productId)
            => Handle(await _mediator.Send(new GetInventoryByProductIdQuery { ProductId = productId }));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize", "WarehouseId", "ProductId", "ProductName" }, Tags = new[] { "inventories-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetInventoriesPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("by-warehouse/{warehouseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "inventories-tag" })]
        public async Task<IActionResult> GetByWarehouse(int warehouseId, [FromQuery] GetInventoryByWarehouseQuery query)
        {
            query.WarehouseId = warehouseId;
            return Handle(await _mediator.Send(query));
        }
    }
}
