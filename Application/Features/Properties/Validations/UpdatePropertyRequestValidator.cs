using Application.Features.Properties.Commands;
using Application.Repositories;
using FluentValidation;

namespace Application.Features.Properties.Validations
{
    public class UpdatePropertyRequestValidator: AbstractValidator<UpdatePropertyRequest>
    {
        public UpdatePropertyRequestValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(request => request.UpdatePropertyDto).SetValidator(new UpdatePropertyValidator(propertyRepo));
        }
    }
}
