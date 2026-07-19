using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrders.validators
{
    public class UpdatePurchaseOrderStatusCommandValidator : AbstractValidator<UpdatePurchaseOrderStatusCommand>
    {
        public UpdatePurchaseOrderStatusCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Status).InclusiveBetween(1, 5);
        }
    }
}
