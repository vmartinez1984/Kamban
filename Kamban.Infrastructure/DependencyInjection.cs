using Kamban.Domain.Interfaces;
using Kamban.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kamban.Infrastructure
{
    /// <summary>
    /// Dependency injection to infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all required service to use infrastructure layer.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns><see cref="IServiceCollection"/> with infrastructure services added to DI.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITareaRepository, TareaRepository>();

            return services;
        }

    }
}