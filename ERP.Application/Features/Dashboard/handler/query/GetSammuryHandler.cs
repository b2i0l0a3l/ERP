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
    public class GetSammuryHandler : IRequestHandler<Summary, Result<SummaryModel>>
    {
        private readonly IDashboardRepo _Repo;
        public GetSammuryHandler(IDashboardRepo repo)
        {
            _Repo = repo;
        }
        public async ValueTask<Result<SummaryModel>> Handle(Summary request, CancellationToken cancellationToken)
        {
            return await _Repo.Summary();
        }
    }
}