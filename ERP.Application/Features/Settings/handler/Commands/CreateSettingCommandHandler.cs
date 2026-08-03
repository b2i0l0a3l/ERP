using ERP.Application.Features.Settings.Requests.Commands;
using ERP.Core.EntityParams.settingParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Settings.Commands
{
    public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, Result<int>>
    {
        private readonly ISettingRepo _repo;
        public CreateSettingCommandHandler(ISettingRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateSettingCommand request, CancellationToken ct)
            => await _repo.Add(new AddSettingParams { CompanyName = request.CompanyName, LogoUrl = request.LogoUrl, Currency = request.Currency, WarehouseId = request.WarehouseId, Tax = request.Tax });
    }
}
