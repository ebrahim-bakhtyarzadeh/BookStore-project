using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Users;

namespace Shop.Presentation.Facade
{
    public static class FacadeBootstrapper
    {

        // بقیه کلاس ها باید اینجکت بشن
        public static void InitFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryFacade, CategoryFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();

            services.AddScoped<IUserFacade, UserFacade>();
        }
    }
}
