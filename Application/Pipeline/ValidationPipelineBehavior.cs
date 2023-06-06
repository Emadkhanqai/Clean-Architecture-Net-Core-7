using Application.Exceptions;
using Application.Pipeline.Contracts;
using FluentValidation;
using MediatR;

namespace Application.Pipeline
{
    public class ValidationPipelineBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest 
        : IRequest<TResponse>, IValidateable
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                List<string> errors = new();
                var validationResults =
                    await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null);
                if (failures.Count() != 0)
                {
                    foreach (var failure in failures)
                    {
                        errors.Add(failure.ErrorMessage);
                    }

                    throw new CustomValidationException(errors, "One or more validation failed");
                }
            }

            return await next();
        }
    }
}
