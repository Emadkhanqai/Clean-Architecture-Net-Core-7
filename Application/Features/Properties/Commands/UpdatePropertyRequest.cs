using Application.Models;
using Application.Pipeline.Contracts;
using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class UpdatePropertyRequest: IRequest<bool>, IValidateable
    {
        public UpdatePropertyDto UpdatePropertyDto { get; set; }
        public UpdatePropertyRequest(UpdatePropertyDto updatePropertyDto)
        {
            UpdatePropertyDto = updatePropertyDto;
        }
    }

    public class UpdatePropertyRequestHandler: IRequestHandler<UpdatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;

        public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }

        public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            Property propertyInDb = await _propertyRepo.GetByIdAsync(request.UpdatePropertyDto.Id);
            if (propertyInDb != null)
            {
                propertyInDb.Name = request.UpdatePropertyDto.Name;
                propertyInDb.Lounge = request.UpdatePropertyDto.Lounge;
                propertyInDb.Dining = request.UpdatePropertyDto.Dining;
                propertyInDb.Rates = request.UpdatePropertyDto.Rates;
                propertyInDb.Bathrooms = request.UpdatePropertyDto.Bathrooms;
                propertyInDb.Bedrooms = request.UpdatePropertyDto.Bedrooms;
                propertyInDb.Address = request.UpdatePropertyDto.Address;
                propertyInDb.Description = request.UpdatePropertyDto.Description;
                propertyInDb.ErfType = request.UpdatePropertyDto.ErfType;
                propertyInDb.FloorSize = request.UpdatePropertyDto.FloorSize;
                propertyInDb.Kitchen = request.UpdatePropertyDto.Kitchen;
                propertyInDb.Levies = request.UpdatePropertyDto.Levies;
                propertyInDb.PetsAllowed = request.UpdatePropertyDto.PetsAllowed;
                propertyInDb.Price = request.UpdatePropertyDto.Price;
                propertyInDb.Type = request.UpdatePropertyDto.Type;

                await _propertyRepo.UpdateAsync(propertyInDb);
                return true;
            }

            return false;
        }
    }
}
