namespace Platform.Models.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string SitemapUrl { get; set; } = string.Empty;
        public bool ShouldScrape { get; set; } = true;
        public ICollection<Recipe> Recipes { get; set; } = [];
    }
}
