using Microsoft.EntityFrameworkCore;
using Nombre_Proyecto.Infrastructure.Persistence.Adapters;

namespace Nombre_Proyecto.Api.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<Nombre_ProyectoDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        return services;
    }
}