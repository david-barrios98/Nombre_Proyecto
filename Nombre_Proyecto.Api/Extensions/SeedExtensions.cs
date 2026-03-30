using Nombre_Proyecto.Infrastructure.Persistence.Adapters;
using Nombre_Proyecto.Infrastructure.Seed;

namespace Nombre_Proyecto.Api.Extensions;

public static class SeedExtensions
{
    public static async Task RunSeedIfNeeded(this WebApplication app, IConfiguration config)
    {
        if (!config.GetValue<bool>("RunSeed")) return;

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Nombre_ProyectoDbContext>();

        await DbInitializer.SeedAsync(context);
    }
}