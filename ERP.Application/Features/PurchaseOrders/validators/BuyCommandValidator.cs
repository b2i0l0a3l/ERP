using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.PurchaseOrders.validators
{
    public class BuyCommandValidator : AbstractValidator<BuyCommand>
    {
        public BuyCommandValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
            RuleFor(x => x.WarehouseId).GreaterThan(0);
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}
