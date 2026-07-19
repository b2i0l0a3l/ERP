using ERP.Application.Features.Settings.Requests.Commands;
using ERP.Core.EntityParams.settingParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Commands
{
    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, Result<bool>>
    {
        private readonly ISettingRepo _repo;
        public UpdateSettingCommandHandler(ISettingRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateSettingCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateSettingParams { CompanyName = request.CompanyName, LogoUrl = request.LogoUrl, Currency = request.Currency, WarehouseId = request.WarehouseId, Tax = request.Tax });
    }
}
