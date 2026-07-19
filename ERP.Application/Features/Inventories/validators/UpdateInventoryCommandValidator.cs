using ERP.Application.Features.Inventories.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Inventories.validators
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator() => RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
    }
}
