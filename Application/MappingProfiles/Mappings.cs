using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // For Create Request
            CreateMap<NewPropertyDto, Property>();

            // For Get Request
            CreateMap<Property, PropertyDto>();

            // For Create Request
            CreateMap<NewImageDto, Image>();

            // For Get Request
            CreateMap<Image, ImageDto>();

        }

    }
}
