using ERP.Application.Features.Warehouses.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Warehouses.validators
{
    public class UpdateWarehouseCommandValidator : AbstractValidator<UpdateWarehouseCommand>
    {
        public UpdateWarehouseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
