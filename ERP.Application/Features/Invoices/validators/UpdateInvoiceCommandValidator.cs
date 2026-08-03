using ERP.Application.Features.Invoices.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Invoices.validators
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SubTotal).GreaterThanOrEqualTo(0);
            RuleFor(x => x.TaxAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DiscountAmount).GreaterThanOrEqualTo(0);
        }
    }
}
