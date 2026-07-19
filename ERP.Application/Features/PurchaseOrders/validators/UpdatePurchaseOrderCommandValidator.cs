using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrders.validators
{
    public class UpdatePurchaseOrderCommandValidator : AbstractValidator<UpdatePurchaseOrderCommand>
    {
        public UpdatePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Status).InclusiveBetween(1, 5);
            RuleFor(x => x.Total).GreaterThanOrEqualTo(0);
        }
    }
}
