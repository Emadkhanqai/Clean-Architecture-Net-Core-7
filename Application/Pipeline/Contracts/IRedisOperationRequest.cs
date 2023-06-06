namespace Application.Pipeline.Contracts
{
    public interface IRedisOperationRequest
    {
        string Key { get; }
    }
}
