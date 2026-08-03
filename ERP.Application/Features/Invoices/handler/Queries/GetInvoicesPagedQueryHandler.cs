using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Queries
{
    public class GetInvoicesPagedQueryHandler : IRequestHandler<GetInvoicesPagedQuery, Result<PagedResult<InvoiceDTO>>>
    {
        private readonly IInvoiceRepo _repo;
        public GetInvoicesPagedQueryHandler(IInvoiceRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<InvoiceDTO>>> Handle(GetInvoicesPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                CustomerId = request.CustomerId,
                SupplierId = request.SupplierId,
                Status = request.Status,
                Type = request.Type
            });
    }
}
