using System;

namespace ERP.Core.Models.DashboardModels
{
    public class BestEmployeeModel
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TotalOrdersCount { get; set; }
        public decimal TotalSalesAmount { get; set; }
    }
}
