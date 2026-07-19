using ERP.Application.Features.SalesOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrders.validators
{
    public class UpdateSalesOrderStatusCommandValidator : AbstractValidator<UpdateSalesOrderStatusCommand>
    {
        public UpdateSalesOrderStatusCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Status).InclusiveBetween(1, 5);
        }
    }
}
