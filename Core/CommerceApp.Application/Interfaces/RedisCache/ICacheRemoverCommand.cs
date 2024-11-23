namespace CommerceApp.Application.Interfaces.RedisCache
{
    public interface ICacheRemoverCommand
    {
        string CacheKey { get; }
    }
}
