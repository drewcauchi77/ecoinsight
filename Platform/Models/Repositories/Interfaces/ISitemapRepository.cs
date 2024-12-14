using Platform.Models.Dto;

namespace Platform.Models.Repositories.Interfaces
{
    public interface ISitemapRepository
    {
        Task<IEnumerable<SitemapDto>> AllSitemaps();
    }
}

