using ERP.Core.Models.SettingModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Settings.Requests.Queries
{
    public record GetSettingByIdQuery : IRequest<Result<SettingDTO>>
    {
        public int Id { get; set; }
    }
}
