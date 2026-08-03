using ERP.Core.enums;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Queries
{
    public record GetInvoicesPagedQuery : IRequest<Result<PagedResult<InvoiceDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public enInvoiceStatus? Status { get; set; }
        public enInvoiceType? Type { get; set; }
    }
}
