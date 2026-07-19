using ERP.Application.Features.CustomerAddresses.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.CustomerAddresses.validators
{
    public class CreateCustomerAddressCommandValidator : AbstractValidator<CreateCustomerAddressCommand>
    {
        public CreateCustomerAddressCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
