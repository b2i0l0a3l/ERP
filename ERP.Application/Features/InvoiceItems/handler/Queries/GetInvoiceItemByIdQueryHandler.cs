using ERP.Application.Features.InvoiceItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Queries
{
    public class GetInvoiceItemByIdQueryHandler : IRequestHandler<GetInvoiceItemByIdQuery, Result<InvoiceItemDTO>>
    {
        private readonly IInvoiceItemRepo _repo;
        public GetInvoiceItemByIdQueryHandler(IInvoiceItemRepo repo) => _repo = repo;
        public async ValueTask<Result<InvoiceItemDTO>> Handle(GetInvoiceItemByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
