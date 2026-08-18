using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.PurchaseOrderItemModels;

namespace ERP.Api.Controller
{
    [Route("api/PurchaseOrderItem")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class PurchaseOrderItemController : BaseController
    {
        private readonly IMediator _mediator;
        public PurchaseOrderItemController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePurchaseOrderItemCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdatePurchaseOrderItemCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeletePurchaseOrderItemCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<PurchaseOrderItemDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "purchase-order-items-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetPurchaseOrderItemByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<PurchaseOrderItemDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "purchase-order-items-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetPurchaseOrderItemsPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
