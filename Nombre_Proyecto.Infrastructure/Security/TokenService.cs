using Nombre_Proyecto.Application.Ports.Outbound;
using Nombre_Proyecto.Shared.Helper;
using Nombre_Proyecto.Core.Application.DTOs;

namespace Nombre_Proyecto.Infrastructure.Security;

/// <summary>
/// Adaptador: Implementaci�n del puerto ITokenService
/// Usa JwtHelper para generar tokens
/// </summary>
public class TokenService : ITokenService
{
    private readonly JwtService _jwtHelper;

    public TokenService(JwtService jwtHelper)
    {
        _jwtHelper = jwtHelper;
    }

    public string GenerateAccessToken(JwtUserDto user)
    {
        return _jwtHelper.GenerateJwtToken(user);
    }

    public string GenerateRefreshToken()
    {
        return _jwtHelper.GenerateRefreshToken();
    }

    public int GetAccessTokenExpirationSeconds()
    {
        return _jwtHelper.GetAccessTokenExpirationSeconds();
    }
}