using System.Collections.Generic;
using ERP.Core.Models.DashboardModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.request.query
{
    public class GetBestProductsQuery : IRequest<Result<List<BestProductModel>>>
    {
        public int Count { get; set; } = 5; 
    }
}
