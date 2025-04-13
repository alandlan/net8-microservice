namespace Catalog.API.Extensions
{
    public static class ServiceExtensionsCollections
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            return services;
        }
    }
}
