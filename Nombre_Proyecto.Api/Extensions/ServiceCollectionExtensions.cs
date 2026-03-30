using MediatR;
using FluentValidation;
using Nombre_Proyecto.Application.Common.Behaviors;
using System.Reflection;

namespace Nombre_Proyecto.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load("Nombre_Proyecto.Application"));

        services.AddValidatorsFromAssembly(Assembly.Load("Nombre_Proyecto.Application"));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}