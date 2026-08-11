using ERP.Application.Features.Products.Requests.Commands;
using ERP.Application.Features.Products.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using System.Security.Claims;

namespace ERP.Api.Controller
{
    [Route("api/Product")]
    [ApiController]
    [Authorize(Policy = AppPolicies.AllRoles)]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command, CancellationToken cancellationToken)
        {
            return Handle(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command,[FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync("products-tag", cancellationToken);
            command.Id = id;
            return Handle(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AppPolicies.StaffOrAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id,[FromServices] IOutputCacheStore cacheStore, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand
            {
                Id = id
            }, cancellationToken);
            await cacheStore.EvictByTagAsync("products-tag", cancellationToken);

            return Handle(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetProductByIdQuery { Id = id }));

        [HttpGet("by-name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetByName(string name)
            => Handle(await _mediator.Send(new GetProductByNameQuery { Name = name }));

        [HttpGet("by-barcode/{barcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetByBarcode(string barcode)
            => Handle(await _mediator.Send(new GetProductByBarcodeQuery { Barcode = barcode }));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize", "ProductName","BarCode", "CategoryId", "BrandId" }, Tags = new[] { "ProductPaged-tag" } )]
        public async Task<IActionResult> GetPaged([FromQuery] GetProductsPagedQuery query)
            => Handle(await _mediator.Send(query));

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [OutputCache(Duration = 180, VaryByQueryKeys = new[] { "PageNumber", "PageSize", "Query" }, Tags = new[] { "ProductPaged-tag" } )]

        public async Task<IActionResult> Search([FromQuery] SearchProductsQuery query)
            => Handle(await _mediator.Send(query));
    }
}
