using ERP.Application.Features.InvoiceItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.InvoiceItems.validators
{
    public class UpdateInvoiceItemCommandValidator : AbstractValidator<UpdateInvoiceItemCommand>
    {
        public UpdateInvoiceItemCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.LineTotal).GreaterThanOrEqualTo(0);
        }
    }
}
