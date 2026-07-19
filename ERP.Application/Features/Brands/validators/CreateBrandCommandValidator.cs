using ERP.Application.Features.Brands.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Brands.validators
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
