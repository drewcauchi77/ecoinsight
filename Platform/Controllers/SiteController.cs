using Microsoft.AspNetCore.Mvc;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteRepository;

        public SiteController(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        // Get: api/site
        [HttpGet]
        public async Task<IActionResult> Get_AllSites()
        {
            var allSites = await _siteRepository.AllSites();
            return Ok(allSites);
        }
    }
}

//INSERT INTO Site(Name, Url, SitemapUrl, ShouldScrape) VALUES ('Name', 'Url', 'SitemapUrl', 1);