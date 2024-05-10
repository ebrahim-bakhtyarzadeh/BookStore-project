using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;


    public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService _domainService)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var parentCategory = await _repository.GetTracking(request.parentId);
        if (parentCategory == null)
        {
            return OperationResult.NotFound();
        }
        parentCategory.AddChild(request.title, request.slug, request.seoData, _domainService);
        _repository.Update(parentCategory);
        await _repository.Save();
        return OperationResult.Success();
    }
}