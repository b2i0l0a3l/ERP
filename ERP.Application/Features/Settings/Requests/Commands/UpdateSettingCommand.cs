using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Requests.Commands
{
    public record UpdateSettingCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "USD";
        public int WarehouseId { get; set; }
        public decimal Tax { get; set; }
    }
}
