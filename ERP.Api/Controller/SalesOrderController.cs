using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Application.Features.Payments.Requests.Queries;
using ERP.Application.Features.SalesOrderItems.Requests.Queries;
using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Application.Features.SalesOrders.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using System.Security.Claims;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.Models.PaymentModels;

namespace ERP.Api.Controller
{
    [Route("api/SalesOrder")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class SalesOrderController : BaseController
    {
        private readonly IMediator _mediator;
        public SalesOrderController(IMediator mediator) => _mediator = mediator;

        [HttpPost("sell")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Sell(SellCommand command, [FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync("sales-orders-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("dashboard-summary-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("SaleRaport-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("BestProducts-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("BestEmployees-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("GetLowItems-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("inventories-tag", cancellationToken);
            return Handle(result);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, [FromQuery] int warehouseId, CancellationToken cancellationToken)
            => Handle(await _mediator.Send(new DeleteSalesOrderCommand { Id = id, WarehouseId = warehouseId }, cancellationToken));
 
        [HttpPut("undo-delete/{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UndoDelete(int id, [FromQuery] int warehouseId, CancellationToken cancellationToken)
            => Handle(await _mediator.Send(new UndoDeleteSalesOrderCommand { Id = id, WarehouseId = warehouseId }, cancellationToken));
 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<SalesOrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "sales-orders-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetSalesOrderByIdQuery { Id = id }));
 
        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<SalesOrderDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize", "CustomerId", "PaymentStatus" }, Tags = new[] { "sales-orders-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetSalesOrdersPagedQuery query)
            => Handle(await _mediator.Send(query));
 
        [HttpGet("{id}/items")]
        [ProducesResponseType(typeof(Result<PagedResult<SalesOrderItemDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "sales-orders-tag" })]
        public async Task<IActionResult> GetItems(int id, [FromQuery] GetSalesOrderItemsByOrderQuery query)
        {
            query.SalesOrderId = id;
            return Handle(await _mediator.Send(query));
        }
 
        [HttpGet("{id}/payments")]
        [ProducesResponseType(typeof(Result<PagedResult<PaymentDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "sales-orders-tag" })]
        public async Task<IActionResult> GetPayments(int id, [FromQuery] GetPaymentsPagedQuery query)
        {
            query.SaleOrderId = id;
            return Handle(await _mediator.Send(query));
        }
 
        [HttpPost("{id}/pay")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pay(int id, CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            command.SaleOrderId = id;
            return Handle(await _mediator.Send(command, cancellationToken));
        }
 
        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(int id, UpdateSalesOrderStatusCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command, cancellationToken));
        }
 
        [HttpPost("cancel")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelSalesOrder(CancelSalesOrderCommand command, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? command.CancelledByUserId;
            command.CancelledByUserId = userId;
            return Handle(await _mediator.Send(command, cancellationToken));
        }
    }
}
