using ERP.Application.Features.Brands.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Brands.validators
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
