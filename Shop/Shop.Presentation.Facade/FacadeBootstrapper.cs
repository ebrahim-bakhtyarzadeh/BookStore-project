using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;

namespace Shop.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryFacade, CategoryFacade>();
        }
    }
}
