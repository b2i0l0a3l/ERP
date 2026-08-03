using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Settings.Requests.Commands
{
    public record DeleteSettingCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
