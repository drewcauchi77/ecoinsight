using Platform.Models.Entities.Linkings;

namespace Platform.Models.Entities
{
    public class Recipe
    {
        // Primary key
        public int Id { get; set; }

        // Recipe title
        public string Title { get; set; } = string.Empty;

        // Small description sentence
        public string Description { get; set; } = string.Empty;

        // URL of the recipe page
        public string SourceUrl { get; set; } = string.Empty;

        // ID where the recipe resides (for scroll to purposes)
        public string SourceAnchor { get; set; } = string.Empty;

        // Ingredients in a JSON stringified format
        public string IngredientList { get; set; } = string.Empty;

        // Main recipe image URL
        public string ImageUrl { get; set; } = string.Empty;

        // True or false - can be frozen
        public bool FreezeFriendly { get; set; }

        // To use vs last modified in sitemap to scrape or not
        public DateTime LastModified { get; set; }

        // Foreign key to site
        public int SiteId { get; set; }

        // Matched site details - can be null
        public Site Site { get; } = null!;

        // Many to many relationship with meal type
        public List<RecipeMealType> RecipeMealTypes { get; } = [];

        // Many to many relationship with ingredients
        public List<RecipeIngredient> RecipeIngredients { get; } = [];
    }
}
