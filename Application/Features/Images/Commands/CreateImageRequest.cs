using Application.Models;
using Application.Pipeline.Contracts;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class CreateImageRequest: IRequest<bool>, IValidateable
    {
        public CreateImageRequest(NewImageDto newImageDto)
        {
            NewImageDto = newImageDto;
        }

        public NewImageDto NewImageDto{ get; set; }
    }

    public class CreateImageRequestHandler: IRequestHandler<CreateImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public CreateImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
        {
            // handle business logic here
            // adding mapping here as well
            Image property = _mapper.Map<Image>(request.NewImageDto);
            await _imageRepo.AddNewAsync(property);
            return true;
        }
    }
}
