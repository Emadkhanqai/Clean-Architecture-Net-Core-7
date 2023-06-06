using Application.Models;
using FluentValidation;

namespace Application.Features.Properties.Validations
{
    // Fluent Validation applied here
    public class NewPropertyValidator: AbstractValidator<NewPropertyDto>
    {
        public NewPropertyValidator()
        {
            RuleFor(np => np.Name)
                .NotEmpty()
                .WithMessage("Property Name is Required")
                .MaximumLength(15)
                .WithMessage("Name should not exceed 15 characters");
        }
    }
}
