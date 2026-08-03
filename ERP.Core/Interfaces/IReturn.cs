using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.EntityParams.returnParams;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IReturnRepo
    {
        Task<Result<int>> Return(ReturnParam returnParam);
        Task<Result> Delete(int ReturnId, string UserId);
        Task<Result> UndoReturn(int ReturnId);
    }
}