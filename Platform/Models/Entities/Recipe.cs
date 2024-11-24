namespace Platform.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty;
        public string SourceAnchor { get; set; } = string.Empty;
        public string ServingSize { get; set; } = string.Empty;
        public int CookTime { get; set; }
        public int PreparationTime { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public int SiteId { get; set; }
        public Site? Site { get; set; }
    }
}
