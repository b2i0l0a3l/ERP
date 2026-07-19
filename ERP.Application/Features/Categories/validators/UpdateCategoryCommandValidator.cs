using ERP.Application.Features.Categories.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Categories.validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
