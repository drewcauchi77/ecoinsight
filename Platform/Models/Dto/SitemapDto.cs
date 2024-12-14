namespace Platform.Models.Dto
{
    public class SitemapDto
    {
        public string Url { get; set; } = string.Empty;
        public bool ShouldScrape { get; set; }
        public int SiteId { get; set; }
    }
}

