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
    public class UpdateImageRequestValidator: AbstractValidator<UpdateImageRequest>
    {
        public UpdateImageRequestValidator(IImageRepo imageRepo, IPropertyRepo propertyRepo)
        {
            RuleFor(request => request.UpdateImageDto).SetValidator(new UpdateImageValidator(imageRepo, propertyRepo));
        }
    }
}
