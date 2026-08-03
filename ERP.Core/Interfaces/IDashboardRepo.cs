using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.DashboardModels;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IDashboardRepo
    {
        Task<Result<SummaryModel>> Summary();
        Task<Result<List<SaleRaport>>> SaleRaport(DateOnly From, DateOnly To);
        Task<Result<List<PurchaseRaport>>> PurchaseRaport(DateOnly From, DateOnly To);
        Task<Result<List<InventoryDTO>>> GetLowStock();
    }
}