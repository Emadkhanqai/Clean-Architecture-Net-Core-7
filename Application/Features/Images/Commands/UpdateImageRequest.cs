using Application.Models;
using Application.Pipeline.Contracts;
using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class UpdateImageRequest: IRequest<bool>, IValidateable
    {
        public UpdateImageRequest(UpdateImageDto updateImageDto)
        {
            UpdateImageDto = updateImageDto;
        }

        public UpdateImageDto UpdateImageDto{ get; set; }
    }

    public class UpdateImageRequestHandler: IRequestHandler<UpdateImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;

        public UpdateImageRequestHandler(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public async Task<bool> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
        {
            Image imageInDb = await _imageRepo.GetByIdAsync(request.UpdateImageDto.Id);
            if (imageInDb != null)
            {
                imageInDb.Name = request.UpdateImageDto.Name;
                imageInDb.Path = request.UpdateImageDto.Path;

                await _imageRepo.UpdateAsync(imageInDb);
                return true;
            }
            return false;
        }
    }
}
