using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.DashboardModels
{
    public class SummaryModel
    {
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalSales { get; set; }
        public int TotalPurchase { get; set; }
        public int TotalPurchaseItems { get; set; }
        public int NotPaidOrders { get; set; }
        public int PartialPaidOrders { get; set; }
        public int FullyPaidOrders { get; set; }
        public int NotPaidPurchase { get; set; }
        public int PartialPaidPurchase { get; set; }
        public int FullyPaidPurchase { get; set; }
    }
}