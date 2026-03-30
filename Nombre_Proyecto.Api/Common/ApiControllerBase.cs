using Microsoft.AspNetCore.Mvc;
using Nombre_Proyecto.Application.Common.Results;
using Nombre_Proyecto.Application.Constants;
using Nombre_Proyecto.Application.DTOs.Common;

namespace Nombre_Proyecto.Api.Common
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ProcessResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(ApiResponse<T>.Success(result.Value!, Messages.GENERAL[MessageKeys.SUCCESS], 200));
            }

            // 1. Determinamos el status code numérico basado en el ErrorType del negocio
            int statusCode = result.ErrorType switch
            {
                "NotFound" => 404,
                "Validation" => 422,
                "Unauthorized" => 401,
                "Conflict" => 409,
                _ => 400
            };

            // 2. Creamos la respuesta con el código entero
            var response = ApiResponse<T>.Failure(result.Error!, statusCode);

            // 3. Devolvemos el ActionResult correcto
            return StatusCode(statusCode, response);
        }
    }
}
