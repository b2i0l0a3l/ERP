using ERP.Application.Features.Invoices.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Invoices.validators
{
    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
