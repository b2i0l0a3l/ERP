using ERP.Core.EntityParams.paymentParams;
using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IPaymentRepo
    {
        Task<Result<PaymentDTO>> GetById(int Id);
        Task<Result<PagedResult<PaymentDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Pay(PayParmas PayParams);
        Task<Result<bool>> UpdatePayment(int paymentId, decimal newAmount, string? paymentMethod = null, CancellationToken cancellationToken = default);
    }
}
