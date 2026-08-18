using ERP.Application.Features.Users.Requests.Commands;
using ERP.Application.Features.Users.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.UserModels;

namespace ERP.Api.Controller
{
    [Route("api/User")]
    [ApiController]
    [Authorize(Policy = AppPolicies.AdminOnly)]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, UpdateUserCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
            => Handle(await _mediator.Send(new DeleteUserCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "users-tag" })]
        public async Task<IActionResult> GetById(string id)
            => Handle(await _mediator.Send(new GetUserByIdQuery { Id = id }));

        [HttpGet("by-email/{email}")]
        [ProducesResponseType(typeof(Result<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "users-tag" })]
        public async Task<IActionResult> GetByEmail(string email)
            => Handle(await _mediator.Send(new GetUserByEmailQuery { Email = email }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<UserDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "users-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetUsersPagedQuery query)
            => Handle(await _mediator.Send(query));
    }
}
