using ERP.Application.Features.Warehouses.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Warehouses.validators
{
    public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
    {
        public CreateWarehouseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
