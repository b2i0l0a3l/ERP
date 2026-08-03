using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Result<int>>
    {
        private readonly IInvoiceRepo _repo;
        public CreateInvoiceCommandHandler(IInvoiceRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateInvoiceCommand request, CancellationToken ct)
            => await _repo.Add(new AddInvoiceParams
            {
                InvoiceNumber = request.InvoiceNumber,
                Type = request.Type,
                Status = request.Status,
                CustomerId = request.CustomerId,
                SupplierId = request.SupplierId,
                IssueDate = request.IssueDate,
                DueDate = request.DueDate,
                SubTotal = request.SubTotal,
                TaxAmount = request.TaxAmount,
                DiscountAmount = request.DiscountAmount,
                TotalAmount = request.TotalAmount,
                Notes = request.Notes,
                CreatedByUserId = request.CreatedByUserId
            });
    }
}
