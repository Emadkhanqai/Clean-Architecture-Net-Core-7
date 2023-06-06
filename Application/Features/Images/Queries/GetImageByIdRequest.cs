using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetImageByIdRequest: IRequest<ImageDto>
    {
        public GetImageByIdRequest(int imageId)
        {
            ImageId = imageId;
        }

        public int ImageId { get; set; }
    }

    public class GetImageByIdRequestHandler: IRequestHandler<GetImageByIdRequest, ImageDto>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public GetImageByIdRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<ImageDto> Handle(GetImageByIdRequest request, CancellationToken cancellationToken)
        {
            Image image = await _imageRepo.GetByIdAsync(request.ImageId);
            if (image != null)
            {
                ImageDto imageDto= _mapper.Map<ImageDto>(image);
                return imageDto;
            }

            return null;
        }
    }
}
