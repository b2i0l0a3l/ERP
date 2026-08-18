using ERP.Application.Features.Suppliers.Requests.Commands;
using ERP.Application.Features.Suppliers.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.SupplierModels;
using ERP.Core.Models.SupplierBalanceModels;
using ERP.Core.Models.PurchaseOrderModels;

namespace ERP.Api.Controller
{
    [Route("api/Supplier")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class SupplierController : BaseController
    {
        private readonly IMediator _mediator;
        public SupplierController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateSupplierCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateSupplierCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteSupplierCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<SupplierDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "suppliers-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetSupplierByIdQuery { Id = id }));

        [HttpGet("by-name/{name}")]
        [ProducesResponseType(typeof(Result<SupplierDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "suppliers-tag" })]
        public async Task<IActionResult> GetByName(string name)
            => Handle(await _mediator.Send(new GetSupplierByNameQuery { Name = name }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<SupplierDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "suppliers-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetSuppliersPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{id}/orders")]
        [ProducesResponseType(typeof(Result<PagedResult<PurchaseOrderDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "suppliers-tag" })]
        public async Task<IActionResult> GetOrders(int id, [FromQuery] GetSupplierOrdersQuery query)
        {
            query.SupplierId = id;
            return Handle(await _mediator.Send(query));
        }

        [HttpGet("{id}/balance")]
        [ProducesResponseType(typeof(Result<SupplierBalanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 60, Tags = new[] { "suppliers-tag" })]
        public async Task<IActionResult> GetBalance(int id)
            => Handle(await _mediator.Send(new GetSupplierBalanceQuery { SupplierId = id }));
    }
}
