using Microsoft.EntityFrameworkCore;
using Platform.Models.Contexts;
using Platform.Models.Dto;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Models.Repositories
{
    public class SitemapRepository: ISitemapRepository
    {
        private readonly DatabaseContext _dbContext;

        public SitemapRepository(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SitemapDto>> AllSitemaps()
        {
            return await _dbContext.Sitemap
                .Select(sm => new SitemapDto
                {
                    Url = sm.Url,
                    ShouldScrape = sm.ShouldScrape,
                    SiteId = sm.SiteId
                })
                .ToListAsync();
        }
    }
}

