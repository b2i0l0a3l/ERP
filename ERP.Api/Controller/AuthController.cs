using System.Security.Claims;
using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controller
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

       
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginCommand command)
            => Handle(await _mediator.Send(command));

  
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(RegisterCommand command)
            => Handle(await _mediator.Send(command));

     
        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPost("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
        {
                        return Handle(await _mediator.Send(command));
        }

        [HttpPost("assign-role")]
        [Authorize(Roles = AppRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AssignRole(AssignRoleCommand command)
            => Handle(await _mediator.Send(command));


        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var firstName = User.FindFirstValue(ClaimTypes.GivenName);
            var lastName = User.FindFirstValue(ClaimTypes.Surname);
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            return Ok(new
            {
                UserId = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Roles = roles
            });
        }
    }
}
