using ERP.Application.Features.SalesOrderItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrderItems.validators
{
    public class UpdateSalesOrderItemCommandValidator : AbstractValidator<UpdateSalesOrderItemCommand>
    {
        public UpdateSalesOrderItemCommandValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Total).GreaterThanOrEqualTo(0);
        }
    }
}
