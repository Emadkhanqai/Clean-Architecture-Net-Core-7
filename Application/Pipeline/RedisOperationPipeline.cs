using Application.Pipeline.Contracts;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

public class RemoveRedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRedisOperationRequest, IRequest<TResponse>
{
    private readonly IDistributedCache _cache;

    public RemoveRedisCacheBehavior(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        await RemoveCacheForKey(request.Key);

        return response;
    }

    private async Task RemoveCacheForKey(string key)
    {
        await _cache.RemoveAsync(key);
    }
}