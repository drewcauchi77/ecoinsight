using Platform.Models.Entities;

namespace Platform.Models.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> AllSites();
        Task<Site> SiteById(int siteId);
        Task<Site> SiteByName(string siteName);
    }
}
