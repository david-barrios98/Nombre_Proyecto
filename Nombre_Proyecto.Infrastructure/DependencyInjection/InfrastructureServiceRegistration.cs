using Microsoft.Extensions.DependencyInjection;
using Nombre_Proyecto.Application.Ports.Outbound;
using Nombre_Proyecto.Infrastructure.Persistence.Repositories;
using Nombre_Proyecto.Infrastructure.Security;
using Nombre_Proyecto.Shared.Helper;

namespace Nombre_Proyecto.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ILoginRepository, LoginRepository>();

            // Services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashPasswordService, HashPasswordService>();
            services.AddSingleton<JwtService>();


            return services;
        }
    }
}