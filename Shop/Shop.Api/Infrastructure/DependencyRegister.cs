namespace Shop.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(this ServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
        }
    }
}
