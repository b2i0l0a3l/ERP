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
    public class GetBestEmployeesHandler : IRequestHandler<GetBestEmployeesQuery, Result<List<BestEmployeeModel>>>
    {
        private readonly IDashboardRepo _repo;

        public GetBestEmployeesHandler(IDashboardRepo repo)
        {
            _repo = repo;
        }

        public async ValueTask<Result<List<BestEmployeeModel>>> Handle(GetBestEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetBestEmployees(request.Count);
        }
    }
}
