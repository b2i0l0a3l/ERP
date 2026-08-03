using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ERP.Api.Controller
{
    [Route("api/PurchaseOrderItem")]
    [ApiController]
    public class PurchaseOrderItemController : BaseController
    {
        private readonly IMediator _mediator;
        public PurchaseOrderItemController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePurchaseOrderItemCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdatePurchaseOrderItemCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeletePurchaseOrderItemCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "purchase-order-items-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetPurchaseOrderItemByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "purchase-order-items-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetPurchaseOrderItemsPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
