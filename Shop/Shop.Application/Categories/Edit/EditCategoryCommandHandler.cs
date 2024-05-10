using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _domainService;

    public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService domainService)
    {
        _categoryRepository = categoryRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var Category = await _categoryRepository.GetTracking(request.Id);
        if (Category == null)
        {
            return OperationResult.NotFound();
        }

        Category.Edit(request.title, request.slug, request.seoData, _domainService);
        _categoryRepository.Update(Category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}