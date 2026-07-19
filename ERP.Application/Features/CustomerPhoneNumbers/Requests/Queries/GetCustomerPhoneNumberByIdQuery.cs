using ERP.Core.Models.CustomerPhoneNumberModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Queries
{
    public record GetCustomerPhoneNumberByIdQuery : IRequest<Result<CustomerPhoneNumberDTO>>
    {
        public int Id { get; set; }
    }
}
