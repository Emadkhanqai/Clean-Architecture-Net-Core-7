using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repositories;
using Domain;
using FluentValidation;

namespace Application.Features.Images.Validations
{
    public class NewImageValidator: AbstractValidator<NewImageDto>
    {
        public NewImageValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(newImage => newImage.PropertyId)
                .MustAsync(async (id, ct) => await propertyRepo.GetByIdAsync(id) is Property existingProperty &&
                                             existingProperty.Id == id)
                .WithMessage("Property does not exists");

            RuleFor(newImage => newImage.Name).NotEmpty();

            RuleFor(newImage => newImage.Path).NotEmpty().MaximumLength(100);





        }
    }
}
