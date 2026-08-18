using ERP.Application.Features.Customers.Requests.Commands;
using ERP.Application.Features.Customers.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.CustomerModels;
using ERP.Core.Models.CustomerBalanceModels;
using ERP.Core.Models.SalesOrderModels;

namespace ERP.Api.Controller
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
            => Handle(await _mediator.Send(command));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            return Handle(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
            => Handle(await _mediator.Send(new DeleteCustomerCommand { Id = id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<CustomerDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "customers-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetCustomerByIdQuery { Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(Result<PagedResult<CustomerDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "customers-tag" })]
        public async Task<IActionResult> GetPaged([FromQuery] GetCustomersPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("{CustomerId}/orders")]
        [ProducesResponseType(typeof(Result<PagedResult<SalesOrderDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, VaryByQueryKeys = new[] { "PageNumber", "PageSize" }, Tags = new[] { "customers-tag" })]
        public async Task<IActionResult> GetOrders([FromQuery] GetCustomerOrdersQuery query)
        {
            return Handle(await _mediator.Send(query));
        }

        [HttpGet("{id}/balance")]
        [ProducesResponseType(typeof(Result<CustomerBalanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 60, Tags = new[] { "customers-tag" })]
        public async Task<IActionResult> GetBalance(int id)
            => Handle(await _mediator.Send(new GetCustomerBalanceQuery { CustomerId = id }));
    }
}
