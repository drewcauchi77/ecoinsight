namespace Platform.Models.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public ICollection<Recipe> Recipes { get; set; } = [];
        public ICollection<Sitemap> Sitemaps { get; set; } = [];
    }
}
