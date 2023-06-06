using Application.Models;
using Application.Repositories;
using Domain;
using FluentValidation;

namespace Application.Features.Properties.Validations
{
    // Fluent Validation applied here
    public class UpdatePropertyValidator: AbstractValidator<UpdatePropertyDto>
    {
        public UpdatePropertyValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(updateProperty => updateProperty.Name)
                .NotEmpty()
                .WithMessage("Property Name is Required")
                .MaximumLength(15)
                .WithMessage("Name should not exceed 15 characters");

            RuleFor(updateProperty => updateProperty.Address)
                .NotEmpty()
                .WithMessage("Address is Required");

            RuleFor(updateProperty => updateProperty.Id)
                .MustAsync(async (id, ct) => await propertyRepo.GetByIdAsync(id) is Property existingProperty && existingProperty.Id == id)
                .WithMessage("Property does not exist");

        }
    }
}
