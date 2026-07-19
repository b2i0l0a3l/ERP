using ERP.Application.Features.Payments.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Payments.validators
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CreatedByUserId).NotEmpty();
        }
    }
}
