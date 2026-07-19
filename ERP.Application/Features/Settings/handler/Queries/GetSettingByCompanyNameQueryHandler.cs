using ERP.Application.Features.Settings.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SettingModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Queries
{
    public class GetSettingByCompanyNameQueryHandler : IRequestHandler<GetSettingByCompanyNameQuery, Result<SettingDTO>>
    {
        private readonly ISettingRepo _repo;
        public GetSettingByCompanyNameQueryHandler(ISettingRepo repo) => _repo = repo;
        public async Task<Result<SettingDTO>> Handle(GetSettingByCompanyNameQuery request, CancellationToken ct)
            => await _repo.GetByCompanyName(request.CompanyName);
    }
}
