using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Requests.Commands
{
    public record DeleteSettingCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
