using Nombre_Proyecto.Application.DTOs.Auth;
using Nombre_Proyecto.Application.DTOs.Common;

namespace Nombre_Proyecto.Application.Ports.Inbound;

/// <summary>
/// Puerto de entrada: Caso de uso para autenticar usuario
/// </summary>
public interface IAuthenticateUserUseCase
{
    Task<ApiResponse<LoginResponseDTO>> ExecuteAsync(LoginRequestDTO request);
}
