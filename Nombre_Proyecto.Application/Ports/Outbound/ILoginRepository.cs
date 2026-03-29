using Nombre_Proyecto.Application.DTOs.Auth;

namespace Nombre_Proyecto.Application.Ports.Outbound
{
    public interface ILoginRepository
    {
        Task<LoginResponseDTO?> GetLoginUserAsync(LoginRequestDTO request);
    }
}
