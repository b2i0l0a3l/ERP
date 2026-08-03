using System.Collections.Generic;
using ERP.Core.enums;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Requests.Commands
{
    public record CreateReturnCommand : IRequest<Result<int>>
    {
        public int WarehouseId { get; set; }
        public int SaleOrderId { get; set; }
        public string? Reason { get; set; }
        public enReturnStatus Status { get; set; }
        public string? CreatedByUserId { get; set; }
        public List<CreateReturnItemDto> Items { get; set; } = new();
    }

    public record CreateReturnItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal RefundAmount { get; set; }
        public enReturnItemCondition Condition { get; set; }
    }
}
