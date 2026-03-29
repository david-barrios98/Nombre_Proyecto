using Microsoft.Extensions.Configuration;
using Nombre_Proyecto.Application.DTOs.Auth;
using Nombre_Proyecto.Application.Ports.Outbound;
using Nombre_Proyecto.Infrastructure.Constants;
using Nombre_Proyecto.Infrastructure.Extensions;
using Nombre_Proyecto.Infrastructure.Persistence.Adapters;
using System.Data;

namespace Nombre_Proyecto.Infrastructure.Persistence.Repositories
{
    public class LoginRepository : SqlConfigServer, ILoginRepository
    {
        private readonly Nombre_ProyectoDbContext _context;

        public LoginRepository(IConfiguration configuration, Nombre_ProyectoDbContext context) : base(configuration)
        {
            _context = context;
        }

        public async Task<LoginResponseDTO?> GetLoginUserAsync(LoginRequestDTO request)
        {

            var parameters = new[]
            {
                CreateParameter("@username", request.username, SqlDbType.VarChar)
            };
            return await ExecuteStoredProcedureSingleAsync(
                StoredProcedures.Auth.sp_login_user,
                parameters,
                reader => SqlDataReaderMapper.MapToDto<LoginResponseDTO>(reader));
        }
    }
}
