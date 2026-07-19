using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.CustomerPhoneNumbers.validators
{
    public class UpdateCustomerPhoneNumberCommandValidator : AbstractValidator<UpdateCustomerPhoneNumberCommand>
    {
        public UpdateCustomerPhoneNumberCommandValidator() => RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
    }
}
