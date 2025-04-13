using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;

namespace Catalog.API.Extensions
{
    public static class ServiceExtensionsCollections
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Program).Assembly;

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
            services.AddValidatorsFromAssembly(assembly);

            services.AddCarter();

            services.AddMarten(options =>
            {
                options.Connection(configuration.GetConnectionString("Database")!);
            }).UseLightweightSessions();

            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }
    }
}
