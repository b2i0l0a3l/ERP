using ERP.Application.Features.Notifications.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Notifications.validators
{
    public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Type).InclusiveBetween(1, 7);
            RuleFor(x => x.Priority).InclusiveBetween(1, 4);
        }
    }
}
