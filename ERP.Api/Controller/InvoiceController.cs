using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.Models.InvoiceModels;

namespace ERP.Api.Controller
{
    [Route("api/Invoice")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class InvoiceController : BaseController
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateInvoiceCommand command, [FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync("invoices-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("dashboard-summary-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("SaleRaport-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("PurchaseRaport-tag", cancellationToken);
            return Handle(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateInvoiceCommand command, [FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync("invoices-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("dashboard-summary-tag", cancellationToken);
            return Handle(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, [FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteInvoiceCommand { Id = id }, cancellationToken);
            await cacheStore.EvictByTagAsync("invoices-tag", cancellationToken);
            await cacheStore.EvictByTagAsync("dashboard-summary-tag", cancellationToken);
            return Handle(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<InvoiceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetInvoiceByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<InvoiceDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetInvoicesPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{id}/items")]
        [ProducesResponseType(typeof(Result<PagedResult<InvoiceItemDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetItems(int id)
            => Handle(await _mediator.Send(new ERP.Application.Features.InvoiceItems.Requests.Queries.GetInvoiceItemsByInvoiceIdQuery { InvoiceId = id }));

        [HttpGet("{id}/pdf")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300, Tags = new[] { "invoices-tag" })]
        public async Task<IActionResult> GetPdf(int id)
        {
            Result<InvoicePdfResponseDto> result = await _mediator.Send(new GetInvoicePdfQuery { Id = id });
            if (!result.IsSuccess)
                return Handle(result);
            return File(result.Value?.PdfBytes!, "application/pdf", $"invoice-{id}.pdf");
        }
    }
}
