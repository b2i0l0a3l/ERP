using ERP.Core.Models.SettingModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Settings.Requests.Queries
{
    public record GetSettingByCompanyNameQuery : IRequest<Result<SettingDTO>>
    {
        public string CompanyName { get; set; } = string.Empty;
    }
}
