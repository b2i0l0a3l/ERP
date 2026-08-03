using ERP.Application.Features.Payments.Requests.Queries;
using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Application.Features.PurchaseOrders.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ERP.Api.Controller
{
    [Route("api/PurchaseOrder")]
    [ApiController]
    public class PurchaseOrderController : BaseController
    {
        private readonly IMediator _mediator;
        public PurchaseOrderController(IMediator mediator) => _mediator = mediator;

        [HttpPost("buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Buy(BuyCommand command, [FromServices] IOutputCacheStore cacheStore)
        {
            var result = await _mediator.Send(command);
            await cacheStore.EvictByTagAsync("inventories-tag", CancellationToken.None);
            return Handle(result);

        } 

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "purchase-orders-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetPurchaseOrderByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "purchase-orders-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetPurchaseOrdersPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{id}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "purchase-orders-tag" })]
        public async Task<IActionResult> GetItems(int id)
            => Handle(await _mediator.Send(new GetPurchaseOrderItemsByOrderQuery { PurchaseOrderId = id }));

        [HttpGet("{id}/payments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "purchase-orders-tag" })]
        public async Task<IActionResult> GetPayments(int id, [FromQuery] GetPaymentsPagedQuery query)
        {
            query.PurchaseOrderId = id;
            return Handle(await _mediator.Send(query));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdatePurchaseOrderCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeletePurchaseOrderCommand { Id = id }));

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(int id, UpdatePurchaseOrderStatusCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }
    }
}
