using Application.Models;

namespace WebAPI
{
    public static class ServiceCollectionExtensions
    {
        // Cache settings
        public static CacheSettings GetCacheSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheSettingConfiguration = configuration.GetSection("CacheSettings");
            services.Configure<CacheSettings>(cacheSettingConfiguration);
            return cacheSettingConfiguration.Get<CacheSettings>();

        }
    }
}
