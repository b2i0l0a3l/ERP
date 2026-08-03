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
    public class GetSaleRaportHandler : IRequestHandler<GetSaleRaportRequest, Result<List<SaleRaport>>>
    {
        private readonly IDashboardRepo _Repo;
        public GetSaleRaportHandler(IDashboardRepo repo)
        {
            _Repo = repo;
        }
        public async ValueTask<Result<List<SaleRaport>>> Handle(GetSaleRaportRequest request, CancellationToken cancellationToken)
        {
            return await _Repo.SaleRaport(request.From, request.To);
        }
    }
}