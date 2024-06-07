using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long parentId, string title, string slug, SeoData seoData) : IBaseCommand<long>;
}
