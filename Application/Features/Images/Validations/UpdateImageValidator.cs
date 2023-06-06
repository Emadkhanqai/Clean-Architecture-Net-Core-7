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
    public class UpdateImageValidator: AbstractValidator<UpdateImageDto>
    {
        public UpdateImageValidator(IImageRepo imageRepo, IPropertyRepo propertyRepo)
        {
            RuleFor(updateImage => updateImage.PropertyId)
                .MustAsync(async (id, ct) => await imageRepo.GetByIdAsync(id) is Image existingImage &&
                                             existingImage.Id == id)
                .WithMessage("Image does not exists");

            RuleFor(updateImage => updateImage.PropertyId)
                .MustAsync(async (id, ct) => await propertyRepo.GetByIdAsync(id) is Property existingProperty &&
                                             existingProperty.Id == id)
                .WithMessage("Property does not exists");

            RuleFor(updateImage => updateImage.Name).NotEmpty();

            RuleFor(updateImage => updateImage.Path).NotEmpty().MaximumLength(100);





        }
    }
}
