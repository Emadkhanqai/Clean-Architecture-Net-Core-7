namespace Application.Pipeline.Contracts
{
    public interface ICacheable
    {
        public string CachingKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
