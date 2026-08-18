using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using ERP.Application.Features.CustomerPhoneNumbers.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.CustomerPhoneNumberModels;

namespace ERP.Api.Controller
{
    [Route("api/CustomerPhoneNumber")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class CustomerPhoneNumberController : BaseController
    {
        private readonly IMediator _mediator;
        public CustomerPhoneNumberController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCustomerPhoneNumberCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateCustomerPhoneNumberCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteCustomerPhoneNumberCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<CustomerPhoneNumberDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "customer-phones-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetCustomerPhoneNumberByIdQuery { Id = id }));
    }
}
