namespace ServiceVersioningMiddleware
{
    using Microsoft.AspNetCore.Http;
    using System.Text.Json;
    using System;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;

    public class ServiceVersioningMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ServiceVersioningMiddlewareOptions options;

        public ServiceVersioningMiddleware(RequestDelegate next, ServiceVersioningMiddlewareOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (this.options.VersioningType.HasFlag(ServiceVersioningType.Header))
            {
                context.Response.OnStarting(state =>
                    {
                        HttpContext httpContext = (HttpContext)state;
                        
                        httpContext.Response.Headers.Add(this.options.VersionHeader, AssemblyVersion.Version.ToString());
                        httpContext.Response.Headers.Add(this.options.AssemblyDescriptionHeader, AssemblyVersion.Description);
                        
                        return Task.FromResult(0);
                    },
                    context);
            }

            if (this.options.VersioningType.HasFlag(ServiceVersioningType.Endpoint))
            {
                if (context.Request.Path.Equals(this.options.Path, StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(
                            new 
                            { 
                                version = AssemblyVersion.Version,
                                serviceName = AssemblyVersion.Name,
                                description = AssemblyVersion.Description,
                            }),
                        Encoding.UTF8);

                    return;
                }
            }
                
            await this.next(context);
        }
    }
}
