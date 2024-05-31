using Common.Application;
using Shop.Domain.CategoryAgg;

namespace Shop.Application.Categories.Delete
{
    public record DeleteCategoryCommand(long id) : IBaseCommand;

    public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteCategory(request.id);
            if (result)
            {
                return OperationResult.Success("Deleted");
            }
            return OperationResult.Error("It is not possible to delete this category");
        }
    }
}
