using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class DeleteImageRequest: IRequest<bool>
    {
        public DeleteImageRequest(int imageId)
        {
            ImageId = imageId;
        }

        public int ImageId { get; set; }
    }

    public class DeleteImageRequestHandler: IRequestHandler<DeleteImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;

        public DeleteImageRequestHandler(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
        {
            Image image = await _imageRepo.GetByIdAsync(request.ImageId);
            if (image != null)
            {
                await _imageRepo.DeleteAsync(image);
                return true;
            }
            return false;
        }
    }
}
