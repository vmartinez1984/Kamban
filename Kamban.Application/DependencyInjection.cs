using AutoMapper;
using Kamban.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Kamban.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all required service to use application layer.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns><see cref="IServiceCollection"/> with application services added to DI.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<TareaMapper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
