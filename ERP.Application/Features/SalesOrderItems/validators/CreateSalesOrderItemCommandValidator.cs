using ERP.Application.Features.SalesOrderItems.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrderItems.validators
{
    public class CreateSalesOrderItemCommandValidator : AbstractValidator<CreateSalesOrderItemCommand>
    {
        public CreateSalesOrderItemCommandValidator()
        {
            RuleFor(x => x.SalesOrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Total).GreaterThanOrEqualTo(0);
        }
    }
}
