using ERP.Application.Features.SalesOrders.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.SalesOrders.validators
{
    public class SellCommandValidator : AbstractValidator<SellCommand>
    {
        public SellCommandValidator()
        {
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}
