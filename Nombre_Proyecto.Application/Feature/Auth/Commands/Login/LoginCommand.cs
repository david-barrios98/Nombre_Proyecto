using MediatR;
using Nombre_Proyecto.Application.Common.Results;
using Nombre_Proyecto.Application.DTOs.Auth;

namespace Nombre_Proyecto.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string username, string password)
        : IRequest<Result<LoginResponseDTO>>;
}