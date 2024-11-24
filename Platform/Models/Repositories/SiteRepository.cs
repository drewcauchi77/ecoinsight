using Microsoft.EntityFrameworkCore;
using Platform.Models.Contexts;
using Platform.Models.Entities;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Models.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly DatabaseContext _dbContext;

        public SiteRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Site>> AllSites()
        {
            return await _dbContext.Site.ToListAsync();
        }

        public async Task<Site> SiteById(int siteId)
        { 
            return await _dbContext.Site.Where(s => s.Id == siteId).FirstOrDefaultAsync();
        }

        public async Task<Site> SiteByName(string siteName)
        {
            return await _dbContext.Site.Where(s => s.Name.ToLower() == siteName.ToLower()).FirstOrDefaultAsync();
        }
    }
}
