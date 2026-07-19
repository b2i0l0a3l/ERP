using ERP.Application.Features.SalesOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrders.validators
{
    public class DeleteSalesOrderCommandValidator : AbstractValidator<DeleteSalesOrderCommand>
    {
        public DeleteSalesOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.WarehouseId).GreaterThan(0);
        }
    }
}
