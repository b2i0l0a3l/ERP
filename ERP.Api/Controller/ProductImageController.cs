using System.Collections.Generic;
using ERP.Application.Features.ProductImages.Requests.Commands;
using ERP.Application.Features.ProductImages.Requests.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

using Microsoft.AspNetCore.Authorization;
using ERP.Core.shared;
using ERP.Core.Models.ProductImageModels;

namespace ERP.Api.Controller
{
    [Route("api/ProductImage")]
    [ApiController]
    [Authorize(Policy = AppPolicies.StaffOrAdmin)]
    public class ProductImageController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductImageController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] CreateProductImageCommand command, [FromServices] IOutputCacheStore cacheStore)
        {
            var result = await _mediator.Send(command);
            await cacheStore.EvictByTagAsync("product-images-tag", CancellationToken.None);
            return Handle(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, [FromServices] IOutputCacheStore cacheStore)
        {
            var result = await _mediator.Send(new DeleteProductImageCommand { Id = id });
            await cacheStore.EvictByTagAsync("product-images-tag", CancellationToken.None);
            return Handle(result);
        }

        [HttpGet("by-product/{productId}")]
        [ProducesResponseType(typeof(Result<List<ProductImageDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OutputCache(Duration = 120, Tags = new[] { "product-images-tag" })]
        public async Task<IActionResult> GetByProduct(int productId)
            => Handle(await _mediator.Send(new GetProductImagesByProductQuery { ProductId = productId }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<ProductImageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 120, Tags = new[] { "product-images-tag" })]
        public async Task<IActionResult> GetById(int id)
            => Handle(await _mediator.Send(new GetProductImageByIdQuery { Id = id }));
    }
}
