using ERP.Application.Features.ProductImages.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.ProductImages.validators
{
    public class CreateProductImageCommandValidator : AbstractValidator<CreateProductImageCommand>
    {
        public CreateProductImageCommandValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);
        }
    }
}
