using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.DashboardModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Dashboard.request.query
{
    public class GetSaleRaportRequest  :IRequest<Result<List<SaleRaport>>>
    {
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
    }
}