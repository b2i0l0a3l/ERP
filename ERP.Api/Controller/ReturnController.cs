using System.Threading.Tasks;
using ERP.Application.Features.Return.Requests.Commands;
using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace ERP.Api.Controller
{
    [Route("api/Return")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class ReturnController : BaseController
    {
        private readonly IMediator _mediator;

        public ReturnController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateReturnCommand command)
            => Handle(await _mediator.Send(command));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle<Result>(await _mediator.Send(new DeleteReturnCommand { ReturnId = id }));

        [HttpPost("{id}/undo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Undo(int id)
            => Handle<Result>(await _mediator.Send(new UndoReturnCommand { ReturnId = id }));
    }
}
