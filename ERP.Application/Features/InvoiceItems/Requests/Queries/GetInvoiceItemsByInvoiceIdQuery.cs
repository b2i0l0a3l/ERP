using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Requests.Queries
{
    public record GetInvoiceItemsByInvoiceIdQuery : IRequest<Result<PagedResult<InvoiceItemDTO>>>
    {
        public int InvoiceId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize {get;set;} = 10;
    }
}
