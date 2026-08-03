using ERP.Application.Features.Users.Requests.Commands;
using FluentValidation;

namespace ERP.Application.Features.Users.validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
