using System;
using ERP.Core.shared;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controller
{
    public class BaseController : ControllerBase
    {

        protected IActionResult Handle<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return HandleError(result.Error!);
            
        }
            private IActionResult HandleError(Error error)
    {
        var problemDetails = new ProblemDetails
        {
            Title = error.Id,
            Detail = error.Description,
            Status = MapErrorTypeToStatusCode(error.Type)
        };

        return error.Type switch
        {
            ErrorType.NotFound => NotFound(problemDetails),
            ErrorType.Validation => BadRequest(problemDetails),
            ErrorType.Conflict => Conflict(problemDetails),
            ErrorType.Unauthorized => Unauthorized(problemDetails),
            ErrorType.Forbidden => StatusCode(StatusCodes.Status403Forbidden, problemDetails),
            _ => StatusCode(StatusCodes.Status500InternalServerError, problemDetails)
        };
    }

    private static int MapErrorTypeToStatusCode(ErrorType type) => type switch
    {
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
        ErrorType.Forbidden => StatusCodes.Status403Forbidden,
        _ => StatusCodes.Status500InternalServerError
    };
  
    }


}