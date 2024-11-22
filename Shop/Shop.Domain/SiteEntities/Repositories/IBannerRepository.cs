using Common.Domain;

namespace Shop.Domain.SiteEntities.Repositories
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        void Delete (Banner banner);
    }
}
