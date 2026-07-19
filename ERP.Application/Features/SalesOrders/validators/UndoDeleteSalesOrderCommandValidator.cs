using ERP.Application.Features.SalesOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrders.validators
{
    public class UndoDeleteSalesOrderCommandValidator : AbstractValidator<UndoDeleteSalesOrderCommand>
    {
        public UndoDeleteSalesOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.WarehouseId).GreaterThan(0);
        }
    }
}
