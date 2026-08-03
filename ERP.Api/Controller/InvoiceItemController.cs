using ERP.Application.Features.InvoiceItems.Requests.Commands;
using ERP.Application.Features.InvoiceItems.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ERP.Api.Controller
{
    [Route("api/InvoiceItem")]
    [ApiController]
    public class InvoiceItemController : BaseController
    {
        private readonly IMediator _mediator;
        public InvoiceItemController(IMediator mediator) => _mediator = mediator;


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteInvoiceItemCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "invoice-items-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetInvoiceItemByIdQuery { Id = id }));
    }
}
