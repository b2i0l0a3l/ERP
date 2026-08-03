using ERP.Application.Features.Categories.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
    {
        private readonly ICategoryRepo _repo;
        public DeleteCategoryCommandHandler(ICategoryRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
