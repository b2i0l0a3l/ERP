using ERP.Application.Features.Categories.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Categories.validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
