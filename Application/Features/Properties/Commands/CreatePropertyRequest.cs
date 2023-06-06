using Application.Models;
using Application.Pipeline.Contracts;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    // IRequest added Mediatr on this class
    public class CreatePropertyRequest: IRequest<bool>, IValidateable
    {
        // Ye aik DTO class hy
        public NewPropertyDto PropertyDto { get; set; }

        public CreatePropertyRequest(NewPropertyDto newPropertyDto)
        {
            PropertyDto = newPropertyDto;
        }
    }

    // MediatR handler 
    public class CreatePropertyRequestHandler : IRequestHandler<CreatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public CreatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            // handle business logic here
            // adding mapping here as well
            Property property = _mapper.Map<Property>(request.PropertyDto);
            property.ListTime = DateTime.Now;
            await _propertyRepo.AddNewAsync(property);
            return true;
        }
    }
}
