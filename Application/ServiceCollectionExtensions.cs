using System.Reflection;
using Application.Pipeline;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    // Register all dependencies here to make it flow to other layers
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services
                // Auto Mapper
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                // MediatR
                .AddMediatR(Assembly.GetExecutingAssembly())
                // Fluent Validation
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                // Custom Exception MediatR
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                // Redis Pipeline
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(CachePipelineBehavior<,>))
                // Remove Redis from Insert/Update/Delete
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RemoveRedisCacheBehavior<,>));

                // Singleton approach => We can use this for logging service, feature flag(to on and off module while deployment), and email service

                // Scoped approach => This is a better option when you want to maintain a state within a request.

                // Transient approach =>  Use this approach for the lightweight service with little or no state.
        }
    }
}
