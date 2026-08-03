using ERP.Application.Features.InvoiceItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.InvoiceItems.validators
{
    public class DeleteInvoiceItemCommandValidator : AbstractValidator<DeleteInvoiceItemCommand>
    {
        public DeleteInvoiceItemCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
