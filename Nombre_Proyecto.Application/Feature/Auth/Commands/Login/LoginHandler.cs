using MediatR;
using Nombre_Proyecto.Application.Common.Results;
using Nombre_Proyecto.Application.Constants;
using Nombre_Proyecto.Application.DTOs.Auth;
using Nombre_Proyecto.Application.Ports.Outbound;
using Nombre_Proyecto.Core.Application.DTOs;

namespace Nombre_Proyecto.Application.Features.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<LoginResponseDTO>>
    {
        private readonly ILoginRepository _repository;
        private readonly IHashPasswordService _hashService;
        private readonly ITokenService _tokenService;

        public LoginHandler(
            ILoginRepository repository,
            IHashPasswordService hashService,
            ITokenService tokenService)
        {
            _repository = repository;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponseDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetLoginUserAsync(request);

            if (user == null)
                return Result<LoginResponseDTO>.Failure(Messages.GENERAL[MessageKeys.USER_NOT_FOUND]);

            if (!_hashService.Verify(request.password, user.password))
                return Result<LoginResponseDTO>.Failure(Messages.GENERAL[MessageKeys.USER_NOT_PASSWORD]);

            JwtUserDto jwtUser = new JwtUserDto
            {
                user_id = user.user_id,
                username = user.username
            };

            var token = _tokenService.GenerateAccessToken(jwtUser);

            user.access_token = token;
            return Result<LoginResponseDTO>.Success(user);
        }
    }
}