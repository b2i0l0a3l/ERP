using FluentValidation;
using Mediator;


namespace ERP.Infrastructure.Shared
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IMessage
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async ValueTask<TResponse> Handle(
            TRequest message,
            MessageHandlerDelegate<TRequest, TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next(message, cancellationToken);
            }

            var context = new ValidationContext<TRequest>(message);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new CustomValidationException(failures);
            }

            return await next(message, cancellationToken);
        }
    }
}