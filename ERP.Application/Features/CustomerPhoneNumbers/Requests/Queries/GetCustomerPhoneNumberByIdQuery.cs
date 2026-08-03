using ERP.Core.Models.CustomerPhoneNumberModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Queries
{
    public record GetCustomerPhoneNumberByIdQuery : IRequest<Result<CustomerPhoneNumberDTO>>
    {
        public int Id { get; set; }
    }
}
