using Nombre_Proyecto.Api.Middleware;

namespace Nombre_Proyecto.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();
        return app;
    }
}