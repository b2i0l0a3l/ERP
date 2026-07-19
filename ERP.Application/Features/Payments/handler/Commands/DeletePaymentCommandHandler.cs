using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Payments.Commands
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Result<bool>>
    {
        private readonly IPaymentRepo _repo;
        public DeletePaymentCommandHandler(IPaymentRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeletePaymentCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
