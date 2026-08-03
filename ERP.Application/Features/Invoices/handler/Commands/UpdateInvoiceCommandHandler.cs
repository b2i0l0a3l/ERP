using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Commands
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Result<bool>>
    {
        private readonly IInvoiceRepo _repo;
        public UpdateInvoiceCommandHandler(IInvoiceRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateInvoiceCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateInvoiceParams
            {
                Status = (enInvoiceStatus)request.Status,
                SubTotal = request.SubTotal,
                TaxAmount = request.TaxAmount,
                DiscountAmount = request.DiscountAmount,
                TotalAmount = request.TotalAmount,
                Notes = request.Notes
            });
    }
}
