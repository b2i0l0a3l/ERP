using ERP.Application.Features.Return.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Return.validators
{
    public class CreateReturnCommandValidator : AbstractValidator<CreateReturnCommand>
    {
        public CreateReturnCommandValidator()
        {
            RuleFor(x => x.WarehouseId).GreaterThan(0);
            RuleFor(x => x.SaleOrderId).GreaterThan(0);
            RuleFor(x => x.Reason).MaximumLength(500);
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Items).NotEmpty().WithMessage("Return items must not be empty.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId).GreaterThan(0);
                item.RuleFor(i => i.Quantity).GreaterThan(0);
                item.RuleFor(i => i.RefundAmount).GreaterThanOrEqualTo(0);
                item.RuleFor(i => i.Condition).IsInEnum();
            });
        }
    }
}
