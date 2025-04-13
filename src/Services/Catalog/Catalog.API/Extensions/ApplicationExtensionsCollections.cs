namespace Catalog.API.Extensions
{
    public static class ApplicationExtensionsCollections
    {
        public static IApplicationBuilder AddApplicationBuilder(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {

            });

            return app;
        }
    }
}
