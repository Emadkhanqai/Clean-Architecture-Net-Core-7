using Application.Pipeline.Contracts;
using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class DeletePropertyRequest: IRequest<bool>, IRedisOperationRequest
    {
        public DeletePropertyRequest(int propertyId)
        {
            PropertyId = propertyId;
        }

        public int PropertyId { get; set; }
        public string Key => $"GetProperties";
    }

    public class DeletePropertyRequestHandler: IRequestHandler<DeletePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;

        public DeletePropertyRequestHandler(IPropertyRepo propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }

        public async Task<bool> Handle(DeletePropertyRequest request, CancellationToken cancellationToken)
        {
            Property property = await _propertyRepo.GetByIdAsync(request.PropertyId);
            if (property != null)
            {
                await _propertyRepo.DeleteAsync(property);
                return true;
            }
            return false;
        }
    }
}
