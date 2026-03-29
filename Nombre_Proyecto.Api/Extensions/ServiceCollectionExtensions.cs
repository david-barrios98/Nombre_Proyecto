using FluentValidation;
using Nombre_Proyecto.Application.Ports.Inbound;
using Nombre_Proyecto.Application.Ports.Outbound;
using Nombre_Proyecto.Application.UseCases;
using Nombre_Proyecto.Application.Validators;
using Nombre_Proyecto.Infrastructure.ExternalServices;
using Nombre_Proyecto.Infrastructure.Persistence.Repositories;
using Nombre_Proyecto.Infrastructure.Security;

namespace Nombre_Proyecto.Api.Extensions;

/// <summary>
/// Extensiones de servicios para inyecci�n de dependencias
/// Organiza los registros siguiendo arquitectura hexagonal
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registra los casos de uso (Puertos de entrada)
    /// </summary>
    public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticateUserUseCase, AuthenticateUserUseCase>();
        return services;
    }

    /// <summary>
    /// Registra los puertos de salida (Repositorios y Servicios)
    /// </summary>
    public static IServiceCollection AddApplicationPorts(this IServiceCollection services)
    {
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IFailedLoginAttemptService, FailedLoginAttemptService>();
        services.AddScoped<IHashPasswordService, HashPasswordService>();

        return services;
    }

    /// <summary>
    /// Registra los validadores (FluentValidation)
    /// </summary>
    public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}