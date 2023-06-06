using Application.Models;
using Application.Pipeline.Contracts;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
    public class GetPropertiesRequest: IRequest<List<PropertyDto>>, ICacheable
    {
        public string CachingKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }

        public GetPropertiesRequest()
        {
            CachingKey = "GetProperties";
        }
    }

    public class GetPropertiesRequestHandler: IRequestHandler<GetPropertiesRequest, List<PropertyDto>>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public GetPropertiesRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> Handle(GetPropertiesRequest request, CancellationToken cancellationToken)
        {
            List<Property> properties = await _propertyRepo.GetAllAsync();
            if (properties != null)
            {
                List<PropertyDto> propertyDto = _mapper.Map<List<PropertyDto>>(properties);
                return propertyDto;
            }

            return null;
        }
    }
}
