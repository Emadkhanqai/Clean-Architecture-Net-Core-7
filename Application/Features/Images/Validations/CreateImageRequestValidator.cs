using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Images.Commands;
using Application.Repositories;
using FluentValidation;

namespace Application.Features.Images.Validations
{
    public class CreateImageRequestValidator: AbstractValidator<CreateImageRequest>
    {
        public CreateImageRequestValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(request => request.NewImageDto).SetValidator(new NewImageValidator(propertyRepo));
        }
    }
}
