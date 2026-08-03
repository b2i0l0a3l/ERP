using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.request.query
{
    public class GetLowStockRequest : IRequest<Result<List<InventoryDTO>>>
    {
        
    }
}