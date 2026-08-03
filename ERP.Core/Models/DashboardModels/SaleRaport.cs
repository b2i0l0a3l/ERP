using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.DashboardModels
{
    public class SaleRaport
    {
        public DateOnly DateValue  {get;set;}
        public decimal TotalRevenue {get;set;}
        public int TotalOrders {get;set;}
        public decimal TotalDiscounts {get;set;}
        public int TotalUnitsSold {get;set;}
        public decimal Profit {get;set;}
    }
}