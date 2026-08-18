using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Application.Features.Payments.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.PaymentModels;

namespace ERP.Api.Controller
{
    [Route("api/Payment")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator) => _mediator = mediator;

        [HttpPost("pay")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Pay(CreatePaymentCommand command)
            => Handle(await _mediator.Send(command));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeletePaymentCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<PaymentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "payments-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetPaymentByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<PaymentDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "payments-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetPaymentsPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdatePaymentCommand command)
        {
            command.PaymentId = id;
            return Handle(await _mediator.Send(command));
        }
    }
}
