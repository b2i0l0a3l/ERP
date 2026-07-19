using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.CustomerPhoneNumbers.validators
{
    public class CreateCustomerPhoneNumberCommandValidator : AbstractValidator<CreateCustomerPhoneNumberCommand>
    {
        public CreateCustomerPhoneNumberCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        }
    }
}
