using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.DashboardModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.request.query
{
    public class GetPurchaseRaportRequest : IRequest<Result<List<PurchaseRaport>>>
    {
          public DateOnly From { get; set; }
        public DateOnly To { get; set; }
    }
}