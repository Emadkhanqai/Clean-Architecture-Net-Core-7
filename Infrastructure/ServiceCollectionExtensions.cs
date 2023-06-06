using Microsoft.Extensions.DependencyInjection;
using Application.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    // Register all dependencies here to make it flow to other layers
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {

            return services
                // Interface ko Implementation pe map kerwaya
                .AddTransient<IPropertyRepo, PropertyRepo>()
                .AddTransient<IImageRepo, ImageRepo>()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
