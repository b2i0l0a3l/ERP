using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Features.Dashboard.request.query;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ERP.Api.Controller
{
    [ApiController]
    [Route("api/Dashboard")]
    public class DashboardController : BaseController
    {
        private readonly IMediator _Mediator ;
        public DashboardController(IMediator mediator)
        {
            _Mediator = mediator;
        }
        [HttpGet("Summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300)] 
        public async Task<IActionResult> Summary( CancellationToken cancellationToken = default)
        {
            return Handle(await _Mediator.Send(new Summary(), cancellationToken));
        }
        [HttpGet("SaleRaport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300,Tags = new[] { "SaleRaport-tag" })] 
        public async Task<IActionResult> SaleRaport([FromQuery]GetSaleRaportRequest req, CancellationToken cancellationToken = default)
        {
            return Handle(await _Mediator.Send(req, cancellationToken));
        }
        [HttpGet("PurchaseRaport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300,Tags = new[] { "PurchaseRaport-tag" })] 
        public async Task<IActionResult> PurchaseRaport([FromQuery]GetPurchaseRaportRequest req, CancellationToken cancellationToken = default)
        {
            return Handle(await _Mediator.Send(req, cancellationToken));
        }
        [HttpGet("GetLowItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [OutputCache(Duration = 300,Tags = new[] { "GetLowItems-tag" })] 
        public async Task<IActionResult> GetLowItems(CancellationToken cancellationToken= default)
        {
            return  Handle(await _Mediator.Send(new GetLowStockRequest(), cancellationToken));
        }
    }
}