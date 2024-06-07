using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;


    public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var parentCategory = await _repository.GetTracking(request.parentId);
        if (parentCategory == null)
        {
            return OperationResult<long>.NotFound();
        }
        parentCategory.AddChild(request.title, request.slug, request.seoData, _domainService);
        _repository.Update(parentCategory);
        await _repository.Save();
        return OperationResult<long>.Success(parentCategory.Id);
    }
}