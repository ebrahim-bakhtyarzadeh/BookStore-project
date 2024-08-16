using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Presentation.Facade.SiteEntities.Slider;
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
            services.AddScoped<IBannerFacade, BannerFacade>();
            services.AddScoped<IRoleFacade, RoleFacade>();
            services.AddScoped<ISellerFacade, SellerFacade>();
            services.AddScoped<ISliderFacade, SliderFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
        }
    }
}
