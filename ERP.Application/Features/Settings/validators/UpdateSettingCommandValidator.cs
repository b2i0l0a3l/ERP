using ERP.Application.Features.Settings.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Settings.validators
{
    public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
    {
        public UpdateSettingCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Currency).NotEmpty().Length(3);
            RuleFor(x => x.WarehouseId).GreaterThan(0);
            RuleFor(x => x.Tax).InclusiveBetween(0, 100);
        }
    }
}
