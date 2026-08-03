using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Settings.Requests.Commands
{
    public record CreateSettingCommand : IRequest<Result<int>>
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "USD";
        public int WarehouseId { get; set; }
        public decimal Tax { get; set; }
    }
}
