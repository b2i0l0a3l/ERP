using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.DashboardModels
{
    public class PurchaseRaport
    {
        public DateOnly DateValue {get;set;}
        public int TotalItemLines {get;set;}
        public int TotalOrdersCount {get;set;}
        public int TotalQuantityPurchased {get;set;}
        public decimal TotalPurchaseAmount {get;set;}
    }
}