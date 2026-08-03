using ERP.Application.Features.Categories.Requests.Commands;
using ERP.Core.EntityParams.categoryParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<int>>
    {
        private readonly ICategoryRepo _repo;
        public CreateCategoryCommandHandler(ICategoryRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateCategoryCommand request, CancellationToken ct)
            => await _repo.Add(new AddCategoryParams { Name = request.Name });
    }
}
