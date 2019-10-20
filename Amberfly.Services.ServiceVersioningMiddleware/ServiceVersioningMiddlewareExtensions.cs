
namespace ServiceVersioningMiddleware
{
    using Microsoft.AspNetCore.Builder;

    public static class ServiceVersioningMiddlewareExtensions
    {
        public static IApplicationBuilder UseServiceVersioning(
            this IApplicationBuilder builder,
            ServiceVersioningMiddlewareOptions options = null)
        {
            options = options ?? new ServiceVersioningMiddlewareOptions();

            return builder.UseMiddleware<ServiceVersioningMiddleware>(options);
        }
    }
}
