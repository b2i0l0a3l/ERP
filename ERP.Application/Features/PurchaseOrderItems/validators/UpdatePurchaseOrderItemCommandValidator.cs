using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrderItems.validators
{
    public class UpdatePurchaseOrderItemCommandValidator : AbstractValidator<UpdatePurchaseOrderItemCommand>
    {
        public UpdatePurchaseOrderItemCommandValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
