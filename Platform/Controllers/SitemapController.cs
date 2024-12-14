using Microsoft.AspNetCore.Mvc;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitemapController : ControllerBase
    {
        private readonly ISitemapRepository _sitemapRepository;

        public SitemapController(ISitemapRepository sitemapRepository)
        {
            _sitemapRepository = sitemapRepository;
        }

        // Get: api/sitemap
        [HttpGet]
        public async Task<IActionResult> Get_AllSitemaps()
        {
            var allSitemaps = await _sitemapRepository.AllSitemaps();
            return Ok(allSitemaps);
        }
    }
}

