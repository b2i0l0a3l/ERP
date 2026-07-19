using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrders.validators
{
    public class DeletePurchaseOrderCommandValidator : AbstractValidator<DeletePurchaseOrderCommand>
    {
        public DeletePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
