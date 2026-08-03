using ERP.Application.Features.Notifications.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Notifications.validators
{
    public class DeleteNotificationCommandValidator : AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
