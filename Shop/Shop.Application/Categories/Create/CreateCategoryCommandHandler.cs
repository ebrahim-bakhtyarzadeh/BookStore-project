using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.title, request.slug, request.seoData, _domainService);
        await _repository.AddAsync(category);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);

    }
}