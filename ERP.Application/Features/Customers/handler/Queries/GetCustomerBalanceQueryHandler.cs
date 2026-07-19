using ERP.Application.Features.Customers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerBalanceModels;
using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Queries
{
    public class GetCustomerBalanceQueryHandler : IRequestHandler<GetCustomerBalanceQuery, Result<CustomerBalanceDTO>>
    {
        private readonly ICustomerRepo _customerRepo;
        public GetCustomerBalanceQueryHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

        public async Task<Result<CustomerBalanceDTO>> Handle(GetCustomerBalanceQuery request, CancellationToken ct)
        {
            Result<CustomerDTO> customerResult = await _customerRepo.GetById(request.CustomerId);
            if (!customerResult.IsSuccess)
                return customerResult.Error!;

            Result<decimal> balanceResult = await _customerRepo.GetCustomerBalance(request.CustomerId);
            if (!balanceResult.IsSuccess)
                return balanceResult.Error!;

            return new CustomerBalanceDTO
            {
                CustomerId = request.CustomerId,
                CustomerName = customerResult.Value!.FristName + " " + customerResult.Value.LastName,
                Balance = balanceResult.Value!
            };
        }
    }
}
