using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Application.Features.Payments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controller
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : BaseContoller
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator) => _mediator = mediator;

        [HttpPost("pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Pay(CreatePaymentCommand command)
            => Handle(await _mediator.Send(command));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeletePaymentCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetPaymentByIdQuery { Id = id }));

        [HttpGet]
          [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> GetPaged([FromQuery] GetPaymentsPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
