using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Features.Dashboard.request.query;
using ERP.Core.Interfaces;
using ERP.Core.Models.DashboardModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.handler.query
{
    public class GetPurchaseRaportHandler : IRequestHandler<GetPurchaseRaportRequest, Result<List<PurchaseRaport>>>
    {
        private readonly IDashboardRepo _Repo;
        public GetPurchaseRaportHandler(IDashboardRepo repo)
        {
            _Repo = repo;
        }
        public async ValueTask<Result<List<PurchaseRaport>>> Handle(GetPurchaseRaportRequest request, CancellationToken cancellationToken)
        {
            return await _Repo.PurchaseRaport(request.From, request.To);
        }
    }
}