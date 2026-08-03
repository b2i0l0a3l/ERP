using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Features.Dashboard.request.query;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.handler.query
{
    public class GetLowStockHandler : IRequestHandler<GetLowStockRequest, Result<List<InventoryDTO>>>
    {
        private readonly IDashboardRepo _Repo;
        public GetLowStockHandler(IDashboardRepo repo)
        {
            _Repo = repo;
        }
        public async ValueTask<Result<List<InventoryDTO>>> Handle(GetLowStockRequest request, CancellationToken cancellationToken)
        {
            return await _Repo.GetLowStock();
        }
    }
}