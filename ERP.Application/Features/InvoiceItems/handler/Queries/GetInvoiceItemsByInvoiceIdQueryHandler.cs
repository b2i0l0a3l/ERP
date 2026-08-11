using ERP.Application.Features.InvoiceItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Queries
{
    public class GetInvoiceItemsByInvoiceIdQueryHandler : IRequestHandler<GetInvoiceItemsByInvoiceIdQuery, Result<PagedResult<InvoiceItemDTO>>>
    {
        private readonly IInvoiceItemRepo _repo;
        public GetInvoiceItemsByInvoiceIdQueryHandler(IInvoiceItemRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<InvoiceItemDTO>>> Handle(GetInvoiceItemsByInvoiceIdQuery request, CancellationToken ct)
            => await _repo.GetByInvoiceId(request.InvoiceId,request.PageNumber,request.PageSize);
    }
}
