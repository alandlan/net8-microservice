using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Extensions
{
    public static class ApplicationExtensionsCollections
    {
        public static IApplicationBuilder AddApplicationBuilder(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionApp =>
            {
                exceptionApp.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                    if (exception is null)
                        return;
                    var problemDetails = new ProblemDetails
                    {
                        Title = exception.Message,
                        Status = StatusCodes.Status500InternalServerError,
                        Detail = exception.Message,
                    };
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, exception.Message);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/problem+json";
                    await context.Response.WriteAsJsonAsync(problemDetails);
                });
            });
            return app;
        }
    }
}
