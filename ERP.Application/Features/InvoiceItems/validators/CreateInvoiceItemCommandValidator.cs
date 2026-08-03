using ERP.Application.Features.InvoiceItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.InvoiceItems.validators
{
    public class CreateInvoiceItemCommandValidator : AbstractValidator<CreateInvoiceItemCommand>
    {
        public CreateInvoiceItemCommandValidator()
        {
            RuleFor(x => x.InvoiceId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.LineTotal).GreaterThanOrEqualTo(0);
        }
    }
}
