using Application.Features.Properties.Commands;
using FluentValidation;

namespace Application.Features.Properties.Validations
{
    // This will now work on Nested objects validations as well
    public class CreatePropertyRequestValidator: AbstractValidator<CreatePropertyRequest>
    {
        public CreatePropertyRequestValidator()
        {
            RuleFor(request => request.PropertyDto).SetValidator(new NewPropertyValidator());
        }
    }
}
