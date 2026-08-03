using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Queries
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Result<InvoiceDTO>>
    {
        private readonly IInvoiceRepo _repo;
        public GetInvoiceByIdQueryHandler(IInvoiceRepo repo) => _repo = repo;
        public async ValueTask<Result<InvoiceDTO>> Handle(GetInvoiceByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
