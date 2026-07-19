using ERP.Application.Features.CustomerAddresses.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.CustomerAddresses.validators
{
    public class UpdateCustomerAddressCommandValidator : AbstractValidator<UpdateCustomerAddressCommand>
    {
        public UpdateCustomerAddressCommandValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
