using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ERP.Api.Controller
{
    [Route("api/Invoice")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateInvoiceCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateInvoiceCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteInvoiceCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetInvoiceByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetInvoicesPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{id}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetItems(int id)
            => Handle(await _mediator.Send(new ERP.Application.Features.InvoiceItems.Requests.Queries.GetInvoiceItemsByInvoiceIdQuery { InvoiceId = id }));

        [HttpGet("{id}/pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetPdf(int id)
        {
            Result<byte[]> result = await _mediator.Send(new GetInvoicePdfQuery { Id = id });
            if (!result.IsSuccess)
                return Handle(result);
            return File(result.Value!, "application/pdf", $"invoice-{id}.pdf");
        }
    }
}
