using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public decimal? CreditLimit { get; set; }   
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
        public virtual ICollection<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; } = new List<CustomerPhoneNumber>(); 
        public virtual ICollection<SalesOrder>? SalesOrders { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}