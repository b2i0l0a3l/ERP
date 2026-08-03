using ERP.Application.Features.Categories.Requests.Commands;
using ERP.Core.EntityParams.categoryParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<bool>>
    {
        private readonly ICategoryRepo _repo;
        public UpdateCategoryCommandHandler(ICategoryRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateCategoryCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateCategoryParams { Name = request.Name });
    }
}
