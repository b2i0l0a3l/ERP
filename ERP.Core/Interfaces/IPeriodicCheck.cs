using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Interfaces
{
    public interface IPeriodicCheck
    {
        string Name { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);

    }
}