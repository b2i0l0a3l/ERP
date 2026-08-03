using ERP.Application.Features.Invoices.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Invoices.validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SubTotal).GreaterThanOrEqualTo(0);
            RuleFor(x => x.TaxAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DiscountAmount).GreaterThanOrEqualTo(0);
        }
    }
}
