namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Add API specific services here
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            // Configure API specific middleware here
            return app;
        }
    }
}
