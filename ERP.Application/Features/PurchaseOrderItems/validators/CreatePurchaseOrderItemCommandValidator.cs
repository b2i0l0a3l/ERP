using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrderItems.validators
{
    public class CreatePurchaseOrderItemCommandValidator : AbstractValidator<CreatePurchaseOrderItemCommand>
    {
        public CreatePurchaseOrderItemCommandValidator()
        {
            RuleFor(x => x.PurchaseOrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
