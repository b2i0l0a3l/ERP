using ERP.Application.Features.Payments.Requests.Queries;
using ERP.Application.Features.SalesOrderItems.Requests.Queries;
using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Application.Features.SalesOrders.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controller
{
    [Route("api/SalesOrder")]
    [ApiController]
    public class SalesOrderController : BaseContoller
    {
        private readonly IMediator _mediator;
        public SalesOrderController(IMediator mediator) => _mediator = mediator;

        [HttpPost("sell")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Sell(SellCommand command)
            => Handle(await _mediator.Send(command));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, [FromQuery] string userId, [FromQuery] int warehouseId)
            => Handle(await _mediator.Send(new DeleteSalesOrderCommand { Id = id, UserId = userId, WarehouseId = warehouseId }));

        [HttpPut("undo-delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UndoDelete(int id, [FromQuery] int warehouseId)
            => Handle(await _mediator.Send(new UndoDeleteSalesOrderCommand { Id = id, WarehouseId = warehouseId }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetSalesOrderByIdQuery { Id = id }));

        [HttpGet]
          [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> GetPaged([FromQuery] GetSalesOrdersPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{id}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItems(int id)
            => Handle(await _mediator.Send(new GetSalesOrderItemsByOrderQuery { SalesOrderId = id }));

        [HttpGet("{id}/payments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPayments(int id, [FromQuery] GetPaymentsPagedQuery query)
        {
            query.SaleOrderId = id;
            return Handle(await _mediator.Send(query));
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(int id, UpdateSalesOrderStatusCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }
    }
}
