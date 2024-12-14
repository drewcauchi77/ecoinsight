namespace Platform.Models.Entities
{
    public class Sitemap
    {
        // Primary key
        public int Id { get; set; }

        // Sitemap URL, each site can have more than 1 sitemap
        public string Url { get; set; } = string.Empty;

        // Whole site decision to scrape or not
        public bool ShouldScrape { get; set; }

        // Foreign key to site
        public int SiteId { get; set; }

        // Matched site details - can be null
        public Site Site { get; } = null!;
    }
}
