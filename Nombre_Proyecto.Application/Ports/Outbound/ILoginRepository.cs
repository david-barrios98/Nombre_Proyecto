using Nombre_Proyecto.Application.DTOs.Auth;
using Nombre_Proyecto.Application.Features.Auth.Commands.Login;

namespace Nombre_Proyecto.Application.Ports.Outbound
{
    public interface ILoginRepository
    {
        Task<LoginResponseDTO?> GetLoginUserAsync(LoginCommand request);
    }
}
