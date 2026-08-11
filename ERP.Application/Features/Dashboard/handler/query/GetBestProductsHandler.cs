using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Dashboard.request.query;
using ERP.Core.Interfaces;
using ERP.Core.Models.DashboardModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.handler.query
{
    public class GetBestProductsHandler : IRequestHandler<GetBestProductsQuery, Result<List<BestProductModel>>>
    {
        private readonly IDashboardRepo _repo;

        public GetBestProductsHandler(IDashboardRepo repo)
        {
            _repo = repo;
        }

        public async ValueTask<Result<List<BestProductModel>>> Handle(GetBestProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetBestProducts(request.Count);
        }
    }
}
