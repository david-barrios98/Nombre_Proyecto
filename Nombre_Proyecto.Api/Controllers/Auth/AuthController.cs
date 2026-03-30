using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nombre_Proyecto.Api.Common;
using Nombre_Proyecto.Application.Features.Auth.Commands.Login;

namespace Nombre_Proyecto.Api.Controllers.Auth
{
    [Route("api/auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return ProcessResult(result);
        }
    }
}