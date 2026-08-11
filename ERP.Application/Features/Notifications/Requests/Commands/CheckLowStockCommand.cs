using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Commands
{
    public class CheckLowStockCommand : IRequest<Result<bool>>
    {
    }
}
