using BuildingBlocks.Behaviors;

namespace Catalog.API.Extensions
{
    public static class ServiceExtensionsCollections
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection services)
        {
            var assembly = typeof(Program).Assembly;
            
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(assembly);

            services.AddCarter();

            return services;
        }
    }
}
