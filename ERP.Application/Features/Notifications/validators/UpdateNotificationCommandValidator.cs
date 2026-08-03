using ERP.Application.Features.Notifications.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Notifications.validators
{
    public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
    {
        public UpdateNotificationCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
