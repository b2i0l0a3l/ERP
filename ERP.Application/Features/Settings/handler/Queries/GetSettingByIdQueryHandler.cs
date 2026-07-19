using ERP.Application.Features.Settings.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SettingModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Queries
{
    public class GetSettingByIdQueryHandler : IRequestHandler<GetSettingByIdQuery, Result<SettingDTO>>
    {
        private readonly ISettingRepo _repo;
        public GetSettingByIdQueryHandler(ISettingRepo repo) => _repo = repo;
        public async Task<Result<SettingDTO>> Handle(GetSettingByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
